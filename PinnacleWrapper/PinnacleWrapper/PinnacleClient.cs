using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Text;
using System;
using Newtonsoft.Json;
using PinnacleWrapper.Enums;
using PinnacleWrapper.Data;
using PinnacleWrapper.Data.Response;
using PinnacleWrapper.Data.Request;

namespace PinnacleWrapper
{
    public class PinnacleClient
    {
        private HttpClient httpClient;

        public string CurrencyCode { get; private set; }
        public OddsFormat OddsFormat { get; private set; }

        private const byte MinimumFeedRefreshWithLast = 5;   // minimum time in seconds between calls when supplying the last timestamp parameter
        private const byte MinimumFeedRefresh = 60;          // minimum time in seconds between calls without last timestamp parameter

        private DateTime? lastFeedRequest/* = null*/;

        private const string BaseAddress = "https://api.pinnaclesports.com/";

        public PinnacleClient(string clientId, string password, string currencyCode, OddsFormat oddsFormat)
        {
            lastFeedRequest = DateTime.Now;
            CurrencyCode = currencyCode;
            OddsFormat = oddsFormat;

            httpClient = new HttpClient { BaseAddress = new Uri(BaseAddress) };

            // put auth header into httpclient
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
            (
                "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", clientId, password)))
            );
        }


        protected async Task<T> JsonGetAsync<T>(string requestUrl, params object[] values)
        {
            var response = await httpClient.GetAsync(string.Format(requestUrl, values)).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed

            // deserialise json async
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        // ToDo: replace requestData object type with "IJsonSerialisable"
        protected async Task<T> JsonPostAsync<T>(string requestUrl, object requestData)
        {
            var requestPostData = JsonConvert.SerializeObject(requestData);

            var response = await httpClient.PostAsync(requestUrl,
                new StringContent(requestPostData, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed

            // deserialise async
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }


        /*---------- OTHERS -------------*/
        public Task<SportsResponse> GetSports() => JsonGetAsync<SportsResponse>(RequestStringSegment.Sports);

        public Task<LeaguesResponse> GetLeagues(int sportId) => JsonGetAsync<LeaguesResponse>(RequestStringSegment.Leagues, sportId);

        public Task<PeriodResponse> GetPeriods(int sportId) => JsonGetAsync<PeriodResponse>(RequestStringSegment.Periods, sportId);

        public Task<InRunningResponse> GetInRunning() => JsonGetAsync<InRunningResponse>(RequestStringSegment.Inrunning);

        public Task<TeaserGroupsResponse> GetTeaserGroups(OddsFormat format) => JsonGetAsync<TeaserGroupsResponse>(RequestStringSegment.TeaserGroups, format);

        public Task<CancellationReasonsResponse> GetCancellationReasons() => JsonGetAsync<CancellationReasonsResponse>(RequestStringSegment.CancellationReasons);

        public Task<CurrenciesResponse> GetCurrencies() => JsonGetAsync<CurrenciesResponse>(RequestStringSegment.Currencies);


        #region GetFeed

        protected string GetFeedRequestUri(int sportId, int[] leagueId, OddsFormat format, string currency, long lastTimestamp, int isLive)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("feed?sportid={0}", sportId);
            if (leagueId.Length > 0)
                sb.AppendFormat("&leagueid={0}", string.Join("-", leagueId));
            sb.AppendFormat("&oddsformat={0}", (int)format);
            sb.AppendFormat("&currencycode={0}", currency);

            if (lastTimestamp > 0)
            {
                sb.AppendFormat("&last={0}", lastTimestamp);
            }

            if (isLive == 0 || isLive == 1)
            {
                sb.AppendFormat("&islive={0}", isLive);
            }

            return sb.ToString();
        }

        protected bool IsFairFeedRequest(long lastTimestamp)
        {
            if (lastFeedRequest.HasValue)
            {
                var minRequestInterval = lastTimestamp > 0 ? MinimumFeedRefreshWithLast : MinimumFeedRefresh;
                var interval = DateTime.Now - lastFeedRequest.Value;

                if (interval.TotalSeconds < minRequestInterval)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        public Task<ClientBalance> GetClientBalance()
        {
            const string uri = "v1/client/balance";
            return JsonGetAsync<ClientBalance>(uri);
        }

        public Task<GetBetsResponse> GetBets(BetListType type, DateTime startDate, DateTime endDate)
        {
            // get request uri
            var sb = new StringBuilder();
            sb.AppendFormat("v1/bets?betlist={0}", type.ToString().ToLower());
            sb.AppendFormat("&fromDate={0}", startDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("&toDate={0}", endDate.ToString("yyyy-MM-dd"));

            var uri = sb.ToString();

            return JsonGetAsync<GetBetsResponse>(uri);
        }

        public Task<GetBetsResponse> GetBets(List<int> betIds)
        {
            // get request uri
            var sb = new StringBuilder();

            sb.AppendFormat("v1/bets?betids={0}", string.Join(",", betIds));

            var uri = sb.ToString();

            return JsonGetAsync<GetBetsResponse>(uri);
        }

        public Task<PlaceBetResponse> PlaceBet(PlaceBetRequest placeBetRequest)
        {
            return JsonPostAsync<PlaceBetResponse>("v1/bets/place", placeBetRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sportId"></param>
        /// <param name="leagueId"></param>
        /// <param name="eventId"></param>
        /// <param name="periodNumber">0 for sports other than soccer, soccer: 0 = Game, 1 = 1st Half, 2 = 2nd Half</param>
        /// <param name="betType"></param>
        /// <param name="oddsFormat"></param>
        /// <param name="team"></param>
        /// <param name="side"></param>
        /// <param name="handicap"></param>
        /// <returns></returns>
        public Task<GetLineResponse> GetLine(int sportId, int leagueId, long eventId, int periodNumber, BetType betType, OddsFormat oddsFormat,
            TeamType? team = null, SideType? side = null, decimal? handicap = null)
        {
            if (team == null)
            {
                if (betType == BetType.MoneyLine || betType == BetType.Spread || betType == BetType.TeamTotalPoints)
                    throw new Exception(string.Format("TeamType is required for {0} Bets!", betType));
            }

            if (side == null)
            {
                if (betType == BetType.TotalPoints || betType == BetType.TeamTotalPoints)
                    throw new Exception(string.Format("SideType is required for {0} Bets!", betType));
            }

            if (handicap == null)
            {
                if (betType == BetType.Spread || betType == BetType.TotalPoints || betType == BetType.TeamTotalPoints)
                    throw new Exception(string.Format("Handicap is required for {0} Bets!", betType));
            }

            // get request uri
            var sb = new StringBuilder();
            sb.AppendFormat("v1/line?sportId={0}", sportId);
            sb.AppendFormat("&leagueId={0}", leagueId);
            sb.AppendFormat("&eventId={0}", eventId);
            sb.AppendFormat("&betType={0}", betType.ToString().ToUpper());
            sb.AppendFormat("&oddsFormat={0}", oddsFormat.ToString().ToUpper());
            sb.AppendFormat("&periodNumber={0}", periodNumber);                 // i.e. for soccer: 0 = Game, 1 = 1st Half, 2 = 2nd Half

            if (team != null)
                sb.AppendFormat("&team={0}", team.ToString().ToUpper());

            if (side != null)
                sb.AppendFormat("&side={0}", side.ToString().ToUpper());

            if (handicap != null)
                sb.AppendFormat("&handicap={0}", handicap.ToString().ToUpper());

            var uri = sb.ToString();

            return JsonGetAsync<GetLineResponse>(uri);
        }

        public Task<GetFixturesResponse> GetFixtures(GetFixturesRequest request)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("v1/fixtures?sportId={0}", request.SportId);

            if (request.LeagueIds != null && request.LeagueIds.Any())
                sb.AppendFormat("&leagueIds={0}", string.Join(",", request.LeagueIds));

            if (request.Since > 0)
                sb.AppendFormat("&since={0}", request.Since);

            if (request.IsLive)
                sb.AppendFormat("&IsLive={0}", 1);


            return JsonGetAsync<GetFixturesResponse>(sb.ToString());
        }

        public Task<GetOddsResponse> GetOdds(GetOddsRequest request)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("v1/odds?sportId={0}", request.SportId);

            if (request.LeagueIds != null && request.LeagueIds.Any())
                sb.AppendFormat("&leagueIds={0}", string.Join(",", request.LeagueIds));

            if (request.Since > 0)
                sb.AppendFormat("&since={0}", request.Since);

            if (request.IsLive)
                sb.AppendFormat("&IsLive={0}", 1);

            sb.AppendFormat("&oddsFormat={0}", OddsFormat);
            sb.AppendFormat("&currencycode={0}", CurrencyCode);

            return JsonGetAsync<GetOddsResponse>(sb.ToString());
        }
    }
}

