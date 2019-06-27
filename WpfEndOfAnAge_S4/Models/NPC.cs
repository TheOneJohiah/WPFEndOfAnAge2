using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEndOfAnAge_S1.Models
{
    public abstract class Npc : Character
    {
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

        public Npc(int id, string name, FactionAlignment factionAlignment, string description)
            : base(id, name, factionAlignment)
        {
            Id = id;
            Name = name;
            Alignment = factionAlignment;
            Description = description;
        }

        protected abstract string InformationText();
    }
}
