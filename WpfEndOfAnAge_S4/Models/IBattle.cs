using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEndOfAnAge_S1.Models
{
    public interface IBattle
    {
        int Damage { get; set; }
        BattleModeName BattleMode { get; set; }

        //
        // methods to return hit point values (0 - 100) for each battle mode
        //
        int Attack();
        int Defend();
        int Retreat();
    }
}

