using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEndOfAnAge_S1.Models
{
    public abstract class Npc : Character, IBattle
    {
        public int Damage { get; set; }
        public int Cohesion { get; set; }
        public BattleModeName BattleMode { get; set; }
        public string Description { get; set; }
        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }

        public Npc()
        {

        }

        public Npc(int id, string name, FactionAlignment factionAlignment, string description, int cohesion, int damage)
            : base(id, name, factionAlignment)
        {
            Id = id;
            Name = name;
            Alignment = factionAlignment;
            Description = description;
            Cohesion = cohesion;
            Damage = damage;
        }

        #region BATTLE METHODS

        /// <summary>
        /// Standard damage
        /// </summary>
        /// <returns>damage</returns>
        public int Attack()
        {
            int damage = Damage * 2;
            return damage;
        }

        /// <summary>
        /// Half damage
        /// </summary>
        /// <returns>halved damage</returns>
        public int Defend()
        {
            int damage = Damage;
            return damage;
        }

        /// <summary>
        /// Nullifies your damage for the round
        /// </summary>
        /// <returns>no damage</returns>
        public int Retreat()
        {
            int damage = 0;
            return damage;
        }

        #endregion

        protected abstract string InformationText();
    }
}
