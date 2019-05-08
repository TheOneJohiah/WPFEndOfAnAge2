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

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "\tYou were raised in a rural village deep in the mountains, undiscovered and unattached to any major power. One day, you discovered a cave near your village",
                "\tUpon entering, you discovered an ancient research lab. The power was dead, and any defensive systems offline. Within the central room of this lab you discovered Ultima.",
                "\tUltima is a state of the art battlesuit, as best you can tell from recovered datachips. Unfortunately, all but the core and helmet were damaged beyong repair.",
                "\tUltima has the potential to change the world, if you use it right. It's up to you to become famous, or fade into obscurity."
            };
        }
    }
}
