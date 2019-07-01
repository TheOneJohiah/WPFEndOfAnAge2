using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEndOfAnAge_S1.Models;
using WpfEndOfAnAge_S3.Models;

namespace WpfEndOfAnAge_S1.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Mezzek Farnasson",
                Age = 23,
                Alignment = Character.FactionAlignment.Unaligned,
                ExperiencePoints = 0,
                LocationId = 0,
                MaxCohesion = 12,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(0001)
                },
                EquippedAttachments = new List<Attachment>()
                {
                    EquippedGearById(1001),
                    EquippedGearById(1002),
                    EquippedGearById(1003),
                    EquippedGearById(1004),
                    EquippedGearById(1005),
                    EquippedGearById(1006)
                }
            };
        }

        private static Attachment EquippedGearById(int id)
        {
            return EquippedBaseGear().FirstOrDefault(i => i.Id == id);
        }

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

        public static Map GameMap()
        {
            Map gameMap = new Map();
            gameMap.StandardGameItems = StandardGameItems();

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 1,
                    Name = "Ancient lab",
                    Description = "You were raised in a rural village deep in the mountains, undiscovered and unattached to any major power. One day,you discovered a cave near your village.\nUpon entering, you discovered an ancient research lab. The power was dead, and any defensive systems offline. Within the central room of this lab you discovered Ultima.\nUltima is a state of the art battlesuit, as best you can tell from recovered datachips. Unfortunately, all but the core and helmet were damaged beyong repair.\nUltima has the potential to change the world, if you use it right. It's up to you to become famous, or fade into obscurity.\nThe lab is dark and dusty. Ultima lies before you, waiting. Do you put the suit on?",
                    VisitedDescription = "The lab is as dusty as ever. Nothing of value remains. You must look to the future! Hurry, as the logner you take, the more the sun dies!",
                    Accessible = true,
                    ModifyXP = 0,
                    LocationOwner = Location.LocationOwnerName.Unaligned,
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(1001),
                        GameItemById(2001)
                    }
                }
                );
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 2,
                    Name = "Your home town",
                    Description = "Nestled between two mountains at the mouth of a river, this place is home. Few people are out and about, most working in the fields. You can just barely make out your home near the back, where both your parents still live.",
                    VisitedDescription = "Your parents are glad you are home, and they greet you joyfully. Nothing of consequence has changed since your last visit, although everyone looks somewhat older.",
                    Accessible = true,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.TSOFP,
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(1001),
                        NpcById(1002)
                    },
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(1002)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 3,
                    Name = "Society of Future Past Mobile City",
                    Description = "An 80 mile long airship that flies using lost technologies, the Societies' flagship is a behemoth. The main courtyard stretches before you, people bustling to the shops around the square. A good place to find a quest or improve your armor.",
                    Accessible = true,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.TSOFP,
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(3001)
                    },
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(0001),
                        NpcById(1006)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 4,
                    Name = "Skeetala",
                    Description = "Thousands of people bustle through the massive square. Most of the many Skeeta villages are represented here, with no two Skeeta wearing clothing of the same color. A good place to find a quest.",
                    Accessible = true,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.Skeeta,
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(1003)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 5,
                    Name = "Kefana Bazaar",
                    Description = "People from all over the world come to the Kefana Bazaar. Ancient artifacts uncovered from within the desert, coupled with quests for expeditions to the same, make it an attractive option for trading.",
                    Accessible = true,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.Kefana,
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(1004)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 6,
                    Name = "The Great Bay",
                    Description = "Numerous Vaitarra factions gather here to squabble and barter. Soldiers, sailors, pirates, stolen goods. Much can be purchased here, for a price.",
                    Accessible = true,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.Vaitarra,
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(0003)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 7,
                    Name = "Nifarra",
                    Description = "This continent is extremely volcanic. An ashen haze hangs over the entrance to the city, much of which is underground. The fortress can be seen off in the distance. From here, it is a menacing black obelisk that looks night impenetrable. A cube shaped hole is in the door.",
                    Accessible = true,
                    ModifyXP = 10,
                    LocationOwner = Location.LocationOwnerName.Niforr,
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(1005)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 8,
                    Name = "The Ancient Fortress",
                    Description = "From the outside, it looked unassailable. The inside isn't much better. Automated defense turrets hide behind every corner, and numerous dastardly traps attempt to prevent your passage. When they register the armor you wear, however, most stand down. In the center of the facility is The Core, an offline hyperadvanced Artificial Intelligence. Therein lies the key to reactivate the star that sustains life on this planet.",
                    Accessible = true,
                    ModifyXP = 30,
                    LocationOwner = Location.LocationOwnerName.Unaligned,
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(0002)
                    }
                }
                );

            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 1);

            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new GameItem(0001, "Your clothes", 1, "Just the clothes you've worn, handspun and rough.", 0),
                new GameItem(0002, "A note from your father", 1, "The note reads, ''", 0),
                new Attachment(1001, "Ultima", 1000000000, 50, 500, 10, "Ultima is a very powerful artifact, a suit core stronger than any other.", 0, Attachment.PartLocationName.CHEST),
                new Attachment(1002, "Shotgauntlet", 20, 20, 10, 10, "Your dad's old shotgauntlet. Decent for stopping bandits and rabid animals.", 10, Attachment.PartLocationName.LEFTARM),
                new Injector(2001, "Nanite injection", 100, 100, 0, "These nanites will patch armor and heal wounds.", 10),
                new Relic(3001, "The Cube", 1000000001, "No one knows what this does, but it is a central display in the SOFP museum. It's a pitch black cube that absorbs all light that falls upon it.", 70, "Nothing seems to happen.", Relic.UseActionType.OPENLOCATION)




            };
        }

        public static List<Attachment> EquippedBaseGear()
        {
            return new List<Attachment>()
            {
                new Attachment(1001, "Base Helmet", 1, 2, 10, 0, "Compatible with all powered armor.", 0, Attachment.PartLocationName.HEAD),
                new Attachment(1002, "Base Chest", 1, 2, 10, 0, "Compatible with all powered armor.", 0, Attachment.PartLocationName.CHEST),
                new Attachment(1003, "Base Left Sleeve", 1, 2, 10, 0, "Compatible with all powered armor.", 0, Attachment.PartLocationName.LEFTARM),
                new Attachment(1004, "Base Right Sleeve", 1, 2, 10, 0, "Compatible with all powered armor.", 0, Attachment.PartLocationName.RIGHTARM),
                new Attachment(1005, "Base Left Leg", 1, 2, 10, 0, "Compatible with all powered armor.", 0, Attachment.PartLocationName.LEFTLEG),
                new Attachment(1006, "Base Right Leg", 1, 2, 10, 0, "Compatible with all powered armor.", 0, Attachment.PartLocationName.RIGHTLEG),
            };
        }
        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Military()
                {
                    Id = 0001,
                    Name = "Overseer Xera",
                    Alignment = Character.FactionAlignment.TSOFP,
                    Description = "Quite possibly the most powerful woman in the world, she is shrounded in mystery. Rumors claim she has ancient artifacts implanted in her very skull that give her the abiltiy to read minds.",
                    Damage = 100,
                    Cohesion = 300,
                    Messages = new List<string>()
                    {
                        "Hello there Mezzek. I've been expecting you.",
                        "So this is the one they've all been talking about. You're not much to look at.",
                        "Who knows, maybe you'll accomplish great things.",
                        "Sometimes art is more than just a symbol.",
                        "That armor you wear is the key to accessing the Archive, also know as the Fortress to most."
                    }                       
                },
                new Military()
                {
                    Id = 0002,
                    Name = "The Core",
                    Alignment = Character.FactionAlignment.Unaligned,
                    Description = "A massive sphere born of ancient technologies, deep in the center of the fortress. It contains the answers to quite literally everything in the universe.",
                    Damage = 50,
                    Cohesion = 300,
                    Messages = new List<string>()
                    {
                        "Authorization codes recognized. Activiting main network... done. Querying auxiliary nodes... done. Error: Plantary network operating at 3.2% of peak. Intializing system scan... done. Error: "
                    }
                },
                new Military()
                {
                    Id = 0003,
                    Name = "Pirate Lord Akazza",
                    Alignment = Character.FactionAlignment.Kefana,
                    Description = "He and his posse leer at you, eyeing your chestplate as you approach. He is a broad, muscled man, who sure looks like a pirate.",
                    Damage = 20,
                    Cohesion = 100,
                    Messages = new List<string>()
                    {
                        "Look at pretty boy over here with the fancy equipment. Reckon he doesn't know which end of a gun is which!",
                        "Hey man, I've heard of you. You don't look too tough!",
                        "Buy something or get lost."
                    }
                },
                new Citizen()
                {
                    Id = 1001,
                    Name = "Farnas",
                    Alignment = Character.FactionAlignment.Unaligned,
                    Description = "Your father. He's in his farming clothes right now, with a straw hat on. He smiles and nods when he sees you.",
                    Messages = new List<string>()
                    {
                        "Son, it sure is good to see you again.",
                        "How have your adventures been? Gotten into any trouble lately?",
                        "Now that you've got your own suit, I think you should have my gauntlet. It's on the table inside, take it."
                    }
                },
                new Citizen()
                {
                    Id = 1002,
                    Name = "Illina",
                    Alignment = Character.FactionAlignment.Unaligned,
                    Description = "Your mother. She's got your baby sister cradled in her arms. As you approach, she quietly shushes you. 'The baby's sleeping.'",
                    Messages = new List<string>()
                    {
                        "How are you doing, Mezzek?",
                        "Your father is so proud of you.",
                        "It warms my heart to see you working to secure a future for your baby sister."
                    }
                },
                new Citizen()
                {
                    Id = 1003,
                    Name = "Skeetala governer",
                    Alignment = Character.FactionAlignment.Skeeta,
                    Description = "A hefty man. he grins as you approach and admiringly eyes your power armor.'",
                    Messages = new List<string>()
                    {
                        "That's a mighty fine piece o' armor you got there. What kinda price does something like that fetch?",
                        "I've heard about you, the virtuous dogooder with the magic armor. Feel free to peruse the various shops.",
                        "If you're looking for a way to save the world, the Society'd be a better bet than this here market."
                    }
                },
                new Citizen()
                {
                    Id = 1004,
                    Name = "A Bazaar lady",
                    Alignment = Character.FactionAlignment.Kefana,
                    Description = "A woman wrapped in many light cloths. They allow her to blend into the desert that surrounds the ship port on all sides. She bows respectfully to you.",
                    Messages = new List<string>()
                    {
                        "The desert spirits foretold your coming.",
                        "Please, help yourself to our wares.",
                        "It is predicted that you can save us all."
                    }
                },
                new Citizen()
                {
                    Id = 1005,
                    Name = "Nifarra Mystic",
                    Alignment = Character.FactionAlignment.Kefana,
                    Description = "This ancient Nifarran is one of the last to recieve immortality treatment, before the knowledge of how to do so was lost in a war.",
                    Messages = new List<string>()
                    {
                        "Good evening. I remember, when I was young, that the location now known as the Fortress was once a regaled center of knowledge. The curators were a neutral party in every war, but the Archive went into lockdown during the last Great War, when an envious group assaulted it to claim it for themselves.",
                        "I don't know how or where you found that chestplate, but I do know this. It belonged to Head Curator Nira. The ancient defenses of the archive will recognize that and stand down, if you carry a Key.",
                        "Accessing the Archive is the only way for us to stabilize the sun."
                    }
                },
                new Citizen()
                {
                    Id = 1006,
                    Name = "A flustured astrologist",
                    Alignment = Character.FactionAlignment.Kefana,
                    Description = "One of the many scientists in the employ of the Society, trying to deteermine how the planet and its sun were trapped in a bubble of space time and isolated from the outside. She looks flustured.",
                    Messages = new List<string>()
                    {
                        "Our sun is dying! Based on recovered information we know all stars gradually increase in luminosity over their lifespans, but recently ours has rapidly increased, far faster than it should be! I'm talking months before we are ll boiled alive!",
                        "We aren't sure what it was, but up until recently there was some kind of undetected stabilizing force on our sun that slowed its rate of decay. That's the only explanation!"
                    }
                }
            };
        }
    }
}
