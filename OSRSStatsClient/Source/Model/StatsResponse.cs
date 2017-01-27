using System.Collections.Generic;

namespace OSRSStatsViewer.Source
{
    public class StatsResponse
    {
        public string PlayerName { get; set; }
        public List<Stats> PlayerStats { get; set; } = new List<Stats>();
    }
}