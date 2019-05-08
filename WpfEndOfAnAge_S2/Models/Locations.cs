using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEndOfAnAge_S1.Models
{
    public class Location
    {
        public enum LocationOwnerName
        {
            Unaligned,
            Niforr,
            Skeeta,
            Kefana,
            Vaitarra,
            TSOFP
        }

        private int _id;
        private string _name;
        private string _description;
        private bool _accessible;
        private int _requiredStanding;
        private LocationOwnerName _locationOwner;
        private int _modifyXP;
        
        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }

        public int RequiredStanding
        {
            get { return _requiredStanding; }
            set { _requiredStanding = value; }
        }

        public LocationOwnerName LocationOwner
        {
            get { return _locationOwner; }
            set { _locationOwner = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int ModifyXP
        {
            get { return _modifyXP; }
            set { _modifyXP = value; }
        }

        #region CONSTRUCTORS
        public Location()
        {

        }
        #endregion
    }
}
