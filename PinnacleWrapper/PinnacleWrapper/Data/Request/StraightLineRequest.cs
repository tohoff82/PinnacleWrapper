using PinnacleWrapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinnacleWrapper.Data.Request
{
    public class StraightLineRequest
    {
        public int LeagueId { get; private set; }
        public decimal? Handicap { get; private set; }
        public string OddsFormat { get; private set; }
        public int SportId { get; private set; }
        public long EventId { get; private set; }
        public int PeriodNumber { get; private set; } //take in class Period.cs
        public string BetType { get; private set; }

        public string Team { get; private set; }
        public string Side { get; private set; }

        public StraightLineRequest(int sportId, int leagueId, long eventId, int period, OddsFormat format, BetType betType, decimal? handicap = null, TeamType? team = null, SideType? side = null)
        {
            SportId = sportId;
            LeagueId = leagueId;
            EventId = eventId;
            PeriodNumber = period;
            OddsFormat = format.ToString();
            BetType = betType.ToString();
            Handicap = handicap;
            Team = team == null ? null : team.ToString();
            Side = side == null ? null : side.ToString();
        }

    }
}
