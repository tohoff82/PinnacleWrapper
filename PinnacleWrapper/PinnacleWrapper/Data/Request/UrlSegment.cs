using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinnacleWrapper.Data.Request
{
    public static class RequestStringSegment
    {
        /*---------- OTHERS -------------*/
        public static string StraightLie()
        {
            var sb = new StringBuilder("v1/line");

            return "!";
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
