using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEndOfAnAge_S1.Models
{
    public class Military : Npc, ISpeak, IBattle
    {
        Random r = new Random();

        public List<string> Messages { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Military()
        {

        }

        public Military(
            int id,
            string name,
            FactionAlignment alignment,
            string description,
            List<string> messages,
            int cohesion,
            int damage)
            : base(id, name, alignment, description, cohesion, damage)
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
