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
        public double Handicap { get; private set; }
        public string OddsFormat { get; private set; }
        public int SportId { get; private set; }
        public long EventId { get; private set; }
        public int PeriodNumber { get; private set; } //take in class Period.cs
        public string BetType { get; private set; }

        public string Team { get; private set; }
        public string Side { get; private set; }

        public StraightLineRequest(int leagueId, double handicap, OddsFormat format, int sportId, long eventId, int period, BetType betType, TeamType team, SideType side)
        {
            LeagueId = leagueId;
            OddsFormat = format.ToString();
            SportId = sportId;
            EventId = eventId;
            PeriodNumber = period;
            BetType = betType.ToString();

            Handicap = betType == Enums.BetType.MONEYLINE ? double.NaN : handicap;

            Team = betType == Enums.BetType.TOTAL_POINTS ? null : team.ToString();
            Side = (betType == Enums.BetType.MONEYLINE || betType  == Enums.BetType.SPREAD) ? null : side.ToString();
        }

    }
}
