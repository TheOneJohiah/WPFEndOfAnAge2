using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEndOfAnAge_S1.Models;

namespace WpfEndOfAnAge_S1.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Bonzo",
                Age = 43,
                Alignment = Character.FactionAlignment.Unaligned,
                ExperiencePoints = 0,
                LocationId = 0
            };
        }
        
        public static Map GameMap()
        {
            Map gameMap = new Map();
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 1,
                    Name = "Ancient lab",
                    Description = "You were raised in a rural village deep in the mountains, undiscovered and unattached to any major power. One day,you discovered a cave near your village.\nUpon entering, you discovered an ancient research lab. The power was dead, and any defensive systems offline. Within the central room of this lab you discovered Ultima.\nUltima is a state of the art battlesuit, as best you can tell from recovered datachips. Unfortunately, all but the core and helmet were damaged beyong repair.\nUltima has the potential to change the world, if you use it right. It's up to you to become famous, or fade into obscurity.\nThe lab is dark and dusty. Ultima lies before you, waiting. Do you put the suit on?",
                    Accessible = true,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.Unaligned
                }
                );
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 2,
                    Name = "Your home town",
                    Description = "Nestled between two mountains at the mouth of a river, this place is home. Few people are out and about, most working in the fields. You can just barely make out your home near the back, where both your parents still live.",
                    Accessible = true,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.TSOFP
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 3,
                    Name = "Society of Future Past Mobile City",
                    Description = "An 80 mile long airship that flies using lost technologies, the Societies' flagship is a behemoth. The main courtyard stretches before you, people bustling to the shops around the square. A good place to find a quest or improve your armor.",
                    Accessible = false,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.TSOFP
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 4,
                    Name = "Skeetala",
                    Description = "Thousands of people bustle through the massive square. Most of the many Skeeta villages are represented here, with no two Skeeta wearing clothing of the same color. A good place to find a quest.",
                    Accessible = false,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.Skeeta
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 5,
                    Name = "Kefana Bazaar",
                    Description = "People from all over the world come to the Kefana Bazaar. Ancient artifacts uncovered from within the desert, coupled with quests for expeditions to the same, make it an attractive option for trading.",
                    Accessible = false,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.Kefana
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 6,
                    Name = "The Great Bay",
                    Description = "Numerous Vaitarra factions gather here to squabble and barter. Soldiers, sailors, pirates, stolen goods. Much can be purchased here, for a price.",
                    Accessible = false,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.Vaitarra
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 7,
                    Name = "Nifarra",
                    Description = "",
                    Accessible = false,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.Niforr
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 8,
                    Name = "The Ancient Fortress",
                    Description = "Numerous Vaitarra factions gather here to squabble and barter. Soldiers, sailors, pirates, stolen goods. Much can be purchased here, for a price.",
                    Accessible = false,
                    ModifyXP = 30,
                    LocationOwner = Location.LocationOwnerName.Unaligned
                }
                );

            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 1);

            return gameMap;
        }
    }
}
