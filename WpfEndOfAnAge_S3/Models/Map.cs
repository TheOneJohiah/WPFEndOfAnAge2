using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEndOfAnAge_S3.Models;

namespace WpfEndOfAnAge_S1.Models
{
    public class Map
    {
        #region FIELDS
        private List<Location> _locations;
        private Location _currentLocation;
        private ObservableCollection<Location> _accessibleLocations;
        private List<GameItem> _standardGameItems;
        #endregion

        #region PROPERTIES
        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }
        public ObservableCollection<Location> AccessibleLocations
        {
            get { return _accessibleLocations; }
            set { _accessibleLocations = value; }
        }
        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Map()
        {
            _locations = new List<Location>();
        }

        #endregion

        #region METHODS

        public void Move(Location location)
        {
            _currentLocation = location;
        }

        public bool CanMove(Location location)
        {
            return location.Accessible;
        }

        public string OpenLocationsByRelic(int relicId)
        {
            string message = "The relic did nothing.";
            Location mapLocation = new Location();

            if (mapLocation != null && mapLocation.RequiredRelicId == relicId)
            {
                mapLocation.Accessible = true;
                message = $"There is a beep of confirmation. The outer defenses of the {mapLocation.Name} have stood down. All that remains is to fight whatever is inside and plunder the interior.";
            }
            return message;
        }

        #endregion
    }
}
