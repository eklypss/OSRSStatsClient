using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace OSRSStatsViewer.Source
{
    public class OSRSStatsClient
    {
        public async Task<StatsResponse> GetUserStatsAsync(string userName, StatsType statsType)
        {
            StatsResponse response = new StatsResponse() { PlayerName = userName };
            using (var webClient = new WebClient())
            {
                using (var stream = await webClient.OpenReadTaskAsync(GetStatsPageURL(userName, statsType)))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var currentLine = string.Empty;
                        int tempIterator = 0;
                        while ((currentLine = reader.ReadLine()) != null)
                        {
                            if (currentLine.Contains("404"))
                            {
                                throw new WebException("User not found!");
                            }

                            string[] values = currentLine.Split(',');
                            if (values.Length >= 3)
                            {
                                response.PlayerStats.Add(new Stats() { Skill = (Skill)Enum.Parse(typeof(Skill), tempIterator.ToString()), Rank = Int32.Parse(values[0]), Level = (ushort)Int32.Parse(values[1]), Experience = values[2] });
                            }
                            tempIterator++;
                        }
                    }
                    return response;
                }
            }
        }

        public StatsResponse GetUserStats(string userName, StatsType statsType)
        {
            StatsResponse response = new StatsResponse() { PlayerName = userName };
            using (var webClient = new WebClient())
            {
                using (var stream = webClient.OpenRead(GetStatsPageURL(userName, statsType)))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var currentLine = string.Empty;
                        int tempIterator = 0;
                        while ((currentLine = reader.ReadLine()) != null)
                        {
                            if (currentLine.Contains("404"))
                            {
                                throw new WebException("User not found!");
                            }
                            string[] values = currentLine.Split(',');
                            if (values.Length >= 3)
                            {
                                Console.WriteLine("Skill: " + Enum.GetName(typeof(Skill), tempIterator) + " Rank: " + values[0] + " Level: " + values[1] + " Experience: " + values[2]);
                                response.PlayerStats.Add(new Stats() { Skill = (Skill)Enum.Parse(typeof(Skill), tempIterator.ToString()), Rank = Int32.Parse(values[0]), Level = (ushort)Int32.Parse(values[1]), Experience = values[2] });
                            }
                            tempIterator++;
                        }
                    }
                    return response;
                }
            }
        }

        private string GetStatsPageURL(string userName, StatsType statsType)
        {
            switch (statsType)
            {
                case StatsType.Normal:
                    return string.Format("http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player={0}", userName);

                case StatsType.Ironman:
                    return string.Format("http://services.runescape.com/m=hiscore_oldschool_ironman/index_lite.ws?player={0}", userName);

                case StatsType.UltimateIronman:
                    return string.Format("http://services.runescape.com/m=hiscore_oldschool_ultimate/index_lite.ws?player={0}", userName);

                case StatsType.HardcoreIronman:
                    return string.Format("http://services.runescape.com/m=hiscore_oldschool_hardcore_ironman/index_lite.ws?player={0}", userName);

                case StatsType.DeadmanMode:
                    return string.Format("http://services.runescape.com/m=hiscore_oldschool_deadman/index_lite.ws?player={0}", userName);

                case StatsType.SeasonalDeadmanMode:
                    return string.Format("http://services.runescape.com/m=hiscore_oldschool_deadman/index_lite.ws?player={0}", userName);

                default:
                    return string.Empty;
            }
        }
    }
}