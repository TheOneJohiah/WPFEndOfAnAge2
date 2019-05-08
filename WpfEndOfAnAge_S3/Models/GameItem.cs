using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEndOfAnAge_S3.Models
{
    public class GameItem
    {
        #region PROPERTIES
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public int ExperiencePoints { get; set; }
        public string UseMessage { get; set; }
        #endregion

        public string Information
        {
            get
            {
                return InformationString();
            }
        }

        #region METHODS
        public virtual string InformationString()
        {
            return $"{Name}: {Description}/nValue: {Value}";
        }
        #endregion

        #region CONSTRUCTORS
        public GameItem(int id, string name, int value, string description, int experiencePoints, string useMessage = "")
        {
            Id = id;
            Name = name;
            Value = value;
            Description = description;
            ExperiencePoints = experiencePoints;
            UseMessage = useMessage;
        }
        #endregion


    }
}
