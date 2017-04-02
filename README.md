# OSRSStatsClient
Very basic wrapper/parser for OSRS hiscores page. Supports all hiscore modes, but only skills. Support for clues and minigames might be added later.

### Example usage

```
var statsClient = new OSRSStatsClient();
var result = await statsClient.GetUserStatsAsync("tuolijakkara", StatsType.Normal);
Console.WriteLine("Example of displaying the XP of a specific skill:");
Console.WriteLine(result.PlayerStats.Where(x => x.Skill == Skill.Attack).First().Experience);
Console.WriteLine("Foreach example:");
foreach (var skill in result.PlayerStats)
{
  Console.WriteLine("Skill: {0} XP: {1} Level: {2} Rank: #{3}", skill.Skill, skill.Experience, skill.Level, skill.Rank);
}
```

### Outputs
```
Example of displaying the XP of a specific skill:
18723479
Foreach example:
Skill: Total XP: 146568672 Level: 1851 Rank: #31872
Skill: Attack XP: 18723479 Level: 99 Rank: #10792
Skill: Defense XP: 16009641 Level: 99 Rank: #13837
Skill: Strength XP: 17707639 Level: 99 Rank: #14070
Skill: Hitpoints XP: 25152175 Level: 99 Rank: #10524
Skill: Ranged XP: 14847347 Level: 99 Rank: #22346
Skill: Prayer XP: 837966 Level: 71 Rank: #66509
Skill: Magic XP: 10863267 Level: 97 Rank: #38094
Skill: Cooking XP: 2197304 Level: 81 Rank: #101363
Skill: Woodcutting XP: 1134659 Level: 74 Rank: #142553
Skill: Fletching XP: 740669 Level: 70 Rank: #224150
Skill: Fishing XP: 6528336 Level: 92 Rank: #18263
Skill: Firemaking XP: 5364855 Level: 90 Rank: #24009
Skill: Crafting XP: 527157 Level: 66 Rank: #140088
Skill: Smithing XP: 674787 Level: 69 Rank: #90325
Skill: Mining XP: 3297099 Level: 85 Rank: #12887
Skill: Herblore XP: 2432313 Level: 82 Rank: #23393
Skill: Agility XP: 1212387 Level: 75 Rank: #46473
Skill: Thieving XP: 594076 Level: 67 Rank: #72964
Skill: Slayer XP: 16326985 Level: 99 Rank: #2054
Skill: Farming XP: 784187 Level: 70 Rank: #66094
Skill: Runecraft XP: 218928 Level: 57 Rank: #82596
Skill: Hunter XP: 278878 Level: 60 Rank: #165098
Skill: Construction XP: 114538 Level: 51 Rank: #130921
```
