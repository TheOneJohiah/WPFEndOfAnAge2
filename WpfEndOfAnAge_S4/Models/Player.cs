using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;
using WpfEndOfAnAge_S3.Models;

namespace WpfEndOfAnAge_S1.Models
{
    public class Player : Character
    {
        #region FIELDS
        private int _cohesion;
        private int _maxCohesion;
        private int _energy;
        private int _maxEnergy;
        private int _damage;
        private int _totalWealth;
        private int _experiencePoints;
        private int _locationId;
        private BattleModeName _battleMode;
        private int _wealth;
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _injectors;
        private ObservableCollection<GameItem> _attachments;
        private ObservableCollection<GameItem> _relic;
        private List<Attachment> _equippedAttachments;
        #endregion

        #region PROPERTIES
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }
        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }
        public int Cohesion
        {
            get { return _cohesion; }
            set
            {
                _cohesion = value;
                if (_cohesion > _maxCohesion)
                {
                    _cohesion = _maxCohesion;
                }

                OnPropertyChanged(nameof(Cohesion));
            }
            
        }


        public int MaxCohesion
        {
            get { return _maxCohesion; }
            set { _maxCohesion = value; }
        }
        public int MaxEnergy
        {
            get { return _maxEnergy; }
            set { _maxEnergy = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        public BattleModeName BattleMode
        {
            get { return _battleMode; }
            set { _battleMode = value; }
        }
        public int TotalWealth
        {
            get { return _totalWealth; }
            set { _totalWealth = value; }
        }
        public int Wealth
        {
            get { return _wealth; }
            set { _wealth = value; }
        }
        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public ObservableCollection<GameItem> Injectors
        {
            get { return _injectors; }
            set { _injectors = value; }
        }
        public ObservableCollection<GameItem> Attachments
        {
            get { return _attachments; }
            set { _attachments = value; }
        }
        public ObservableCollection<GameItem> Relic
        {
            get { return _relic; }
            set { _relic = value; }
        }
        public List<Attachment> EquippedAttachments
        {
            get { return _equippedAttachments; }
            set { _equippedAttachments = value; }
        }
        public int Energy
        {
            get { return _energy; }
            set { _energy = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Player()
        {   
            _locationsVisited = new List<Location>();
            _injectors = new ObservableCollection<GameItem>();
            _attachments = new ObservableCollection<GameItem>();
            _relic = new ObservableCollection<GameItem>();
            _equippedAttachments = new List<Attachment>();
            
        }
        
        #endregion

        #region METHODS

        /// <summary>
        /// override the default greeting in the Character class to include faction alignment/nonalignment
        /// </summary>
        /// <returns>default greeting</returns>
        public override string DefaultGreeting()
        {
            if (_alignment.ToString() == "Unaligned")
            {
                return $"Hello, my name is {_name}.";
            }
            else if (_alignment.ToString() != "TSOFP")
            {
                return $"Hello, my name is {_name} and I serve {_alignment}.";
            }
            else
            {
                return $"Hello, my name is {_name} and I am a member of The Society of Future Past.";
            }

        }

        public override FactionAlignment ChangeAlignment()
        {
            throw new NotImplementedException();
            //TODO: Make method change player's faction alignment based on output from a popup window for this purpose
        }

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        public void UpdateInventoryCategories()
        {
            Injectors.Clear();
            Attachments.Clear();
            Relic.Clear();

            foreach (var gameItem in _inventory)
            {
                if (gameItem is Injector) Injectors.Add(gameItem);
                if (gameItem is Attachment) Attachments.Add(gameItem);
                if (gameItem is Relic) Relic.Add(gameItem);
            }
        }

        public void CalculateWealth()
        {
            TotalWealth = _inventory.Sum(i => i.Value) + _wealth;
        }

        /// <summary>
        /// add selected item to inventory
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
        }

        /// <summary>
        /// remove selected item from inventory
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                Inventory.Remove(selectedGameItem);
            }
        }

        public void RecalculateMaxCohesion()
        {
            _maxCohesion = 0;
            foreach (Attachment item in _equippedAttachments)
            {
                _maxCohesion = _maxCohesion + item.Cohesion;
            }
            OnPropertyChanged(nameof(MaxCohesion));
        }

        public void RecalculateDamage()
        {
            _damage = 0;
            foreach (Attachment item in _equippedAttachments)
            {
                _damage = _damage + item.Damage;
            }
            OnPropertyChanged(nameof(Damage));
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
        #endregion

        #region EVENTS



        #endregion

    }
}
