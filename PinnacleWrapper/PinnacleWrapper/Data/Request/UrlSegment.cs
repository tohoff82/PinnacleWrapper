using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinnacleWrapper.Data.Request
{
    public static class UrlSegment
    {
        /*---------- LINE -------------*/
        public static string StraightLine(StraightLineRequest request)
        {
            var sb = new StringBuilder("v1/line");
            sb.AppendFormat("?leagueid={0}", request.LeagueId);
            sb.AppendFormat("&oddsformat={0}", request.OddsFormat);
            sb.AppendFormat("&sportid={0}", request.SportId);
            sb.AppendFormat("&eventid={0}", request.EventId);
            sb.AppendFormat("&periodnumber={0}", request.PeriodNumber);
            sb.AppendFormat("&bettype={0}", request.BetType);

            if (request.Handicap != null) sb.AppendFormat("&handicap={0}", request.Handicap);
            if (request.Team != null) sb.AppendFormat("&team={0}", request.Team);
            if (request.Side != null) sb.AppendFormat("&side={0}", request.Side);

            return sb.ToString();
        }

        /*---------------- OTHERS METHODS ----------------*/
        public static string Sports { get; private set; } = "v2/sports";

        public static string Leagues { get; private set; } = "v2/leagues?sportid={0}";

        public static string Periods { get; private set; } = "v1/periods?sportid={0}";

        public static string Inrunning { get; private set; } = "v1/inrunning";

        public static string TeaserGroups { get; private set; } = "v1/teaser/groups?oddsformat={0}";

        public static string CancellationReasons { get; private set; } = "v1/cancellationreasons";

        public static string Currencies { get; private set; } = "v2/currencies";
    }
}
