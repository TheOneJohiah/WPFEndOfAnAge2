using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEndOfAnAge_S1.Models
{
    public abstract class Character : ObservableObject
    {
        #region ENUMERABLES

        public enum FactionAlignment
        {
            Unaligned,
            Niforr,
            Skeeta,
            Kefana,
            Vaitarra,
            TSOFP
        }

        #endregion

        #region FIELDS

        protected int _id;
        protected string _name;
        protected int _locationId;
        protected int _age;
        protected FactionAlignment _alignment;

        #endregion

        #region PROPERTIES

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public FactionAlignment Alignment
        {
            get { return _alignment; }
            set { _alignment = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(int id, string name, FactionAlignment alignment, int locationId)
        {
            _id = id;
            _name = name;
            _alignment = alignment;
            _locationId = locationId;
        }

        #endregion

        #region METHODS

        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I am a member of {_alignment}.";
        }

        public abstract FactionAlignment ChangeAlignment();
        #endregion
    }
}
