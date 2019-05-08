using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEndOfAnAge_S3.Models
{
    public class Injector : GameItem
    {
        public int CohesionChange { get; set; }
        public int EnergyChange { get; set; }

        public Injector(int id, string name, int value, int cohesionChange, int energyChange, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
        {
            CohesionChange = cohesionChange;
            EnergyChange = energyChange;
        }
        public override string InformationString()
        {
            if (CohesionChange != 0)
            {
                return $"{Name}: {Description}\nCohesion: {CohesionChange}";
            }
            else if(EnergyChange != 0)
            {
                return $"{Name}: {Description}\nEnergy: {EnergyChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }

    }
}
