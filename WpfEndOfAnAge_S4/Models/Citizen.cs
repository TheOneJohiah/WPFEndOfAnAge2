using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEndOfAnAge_S1.Models
{
    public class Citizen : Npc, ISpeak
    {
        Random r = new Random();

        public List<string> Messages { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Citizen()
        {

        }

        public Citizen(int id, string name, FactionAlignment factionAlignment, string description, List<string> messages)
            : base(id, name, factionAlignment, description)
        {
            Messages = messages;
        }

        /// <summary>
        /// generate a message or use default
        /// </summary>
        /// <returns>message text</returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        private string GetMessage()
        {
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        public override FactionAlignment ChangeAlignment()
        {
            throw new NotImplementedException();
        }
    }
}
