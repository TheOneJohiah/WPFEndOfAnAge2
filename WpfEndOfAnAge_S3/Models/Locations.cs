using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfEndOfAnAge_S3.Models;

namespace WpfEndOfAnAge_S1.Models
{
    public class Location : ObservableObject
    {
        #region ENUMS
        public enum LocationOwnerName
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
        private int _id;
        private string _name;
        private string _description;
        private string _visitedDescription;
        private bool _accessible;
        private int _requiredStanding;
        private int _requiredRelicId;
        private LocationOwnerName _locationOwner;
        private int _modifyXP;
        private ObservableCollection<GameItem> _gameItems;
        #endregion

        #region PROPERTIES
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

        public int RequiredRelicId
        {
            get { return _requiredRelicId; }
            set { _requiredRelicId = value; }
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
        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        public string VisitedDescription
        {
            get { return _visitedDescription; }
            set { _visitedDescription = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
        }
        #endregion

        #region METHODS
        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItem> updatedLocationGameItems = new ObservableCollection<GameItem>();

            foreach (GameItem GameItem in _gameItems)
            {
                updatedLocationGameItems.Add(GameItem);
            }

            GameItems.Clear();

            foreach (GameItem gameItem in updatedLocationGameItems)
            {
                GameItems.Add(gameItem);
            }
        }

        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Add(selectedGameItem);
            }

            UpdateLocationGameItems();
        }

        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Remove(selectedGameItem);
            }

            UpdateLocationGameItems();
        }
        #endregion
    }
}
