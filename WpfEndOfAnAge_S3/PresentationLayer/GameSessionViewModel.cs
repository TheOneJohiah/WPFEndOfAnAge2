using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using WpfEndOfAnAge_S1;
using WpfEndOfAnAge_S1.Models;
using WpfEndOfAnAge_S1.DataLayer;
using WpfEndOfAnAge_S3.Models;
using System.Windows;

namespace WpfEndOfAnAge_S1.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region ENUMS



        #endregion

        #region FIELDS

        private DateTime _gameStartTime;
        private string _gameTimeDisplay;
        private TimeSpan _gameTime;

        private Player _player;

        private Map _gameMap;
        private Location _currentLocation;
        private ObservableCollection<Location> _accessibleLocations;

        private string _currentLocationInformation;
        private GameItem _currentGameItem;
        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public ObservableCollection<Location> AccessibleLocations
        {
            get
            {
                return _accessibleLocations;
            }
            set
            {
                _accessibleLocations = value;
                OnPropertyChanged(nameof(AccessibleLocations));
            }
        }

        public string MissionTimeDisplay
        {
            get { return _gameTimeDisplay; }
            set
            {
                _gameTimeDisplay = value;
                OnPropertyChanged(nameof(MissionTimeDisplay));
            }
        }

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

        public bool IsFortressVisible { get; set; }
        public bool IsSkeetalaVisible { get; set; }
        public bool IsSocietyVisible { get; set; }
        public bool IsNifarraVisible { get; set; }
        public bool IsKefanaVisible { get; set; }
        public bool IsBayVisible { get; set; }
        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            Map gameMap)
        {
            _player = player;
            _gameMap = gameMap;

            _currentLocation = _gameMap.CurrentLocation;
            _accessibleLocations = new ObservableCollection<Location>();

            InitializeView();
        }

        public void EquipGameItem()
        {
            Attachment selectedGameItem = _currentGameItem as Attachment;
            foreach (Attachment item in _player.EquippedAttachments)
            {
                if (selectedGameItem.PartLocation == item.PartLocation)
                {
                    _player.EquippedAttachments.Remove(item);
                    _player.EquippedAttachments.Add(selectedGameItem);
                    _player.RemoveGameItemFromInventory(_currentGameItem);
                    _player.AddGameItemToInventory(item);
                    _player.RecalculateMaxCohesion();
                    break;
                }
            }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initial setup of the game session view
        /// </summary>
        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            GameTimer();

            SetLocationVisibility();
            UpdateAccessibleLocations();
            MoveToAncientLab();
            _player.UpdateInventoryCategories();
        }


        internal void MoveToAncientLab()
        {
            CurrentLocation = _accessibleLocations.FirstOrDefault(l => l.Id == 1);
            OnPlayerMove();
        }
        internal void MoveToHometown()
        {
            CurrentLocation = _accessibleLocations.FirstOrDefault(l => l.Id == 2);
            OnPlayerMove();
        }
        internal void MoveToSOFP()
        {
            CurrentLocation = _accessibleLocations.FirstOrDefault(l => l.Id == 3);
            OnPlayerMove();
        }
        internal void MoveToSkeetala()
        {
            CurrentLocation = _accessibleLocations.FirstOrDefault(l => l.Id == 4);
            OnPlayerMove();
        }
        internal void MoveToKefana()
        {
            CurrentLocation = _accessibleLocations.FirstOrDefault(l => l.Id == 5);
            OnPlayerMove();
        }
        internal void MoveToBay()
        {
            CurrentLocation = _accessibleLocations.FirstOrDefault(l => l.Id == 6);
            OnPlayerMove();
        }
        internal void MoveToNifarra()
        {
            CurrentLocation = _accessibleLocations.FirstOrDefault(l => l.Id == 7);
            OnPlayerMove();
        }
        internal void MoveToFortress()
        {
            CurrentLocation = _accessibleLocations.FirstOrDefault(l => l.Id == 8);
            OnPlayerMove();
        }

        private void SetLocationVisibility()
        {
            foreach (Location location in _gameMap.Locations)
            {
                if (location.Accessible == false)
                {
                    switch (location.Id)
                    {
                        case 3:
                            IsSocietyVisible = false;
                            break;
                        case 4:
                            IsSkeetalaVisible = false;
                            break;
                        case 5:
                            IsKefanaVisible = false;
                            break;
                        case 6:
                            IsBayVisible = false;
                            break;
                        case 7:
                            IsNifarraVisible = false;
                            break;
                        case 8:
                            IsFortressVisible = false;
                            break;
                        default:
                            break;
                    }
                }
                if (location.Accessible == true)
                {
                    switch (location.Id)
                    {
                        case 3:
                            IsSocietyVisible = true;
                            break;
                        case 4:
                            IsSkeetalaVisible = true;
                            break;
                        case 5:
                            IsKefanaVisible = true;
                            break;
                        case 6:
                            IsBayVisible = true;
                            break;
                        case 7:
                            IsNifarraVisible = true;
                            break;
                        case 8:
                            IsFortressVisible = true;
                            break;
                        default:
                            break;
                    }
                }

            }
        }

        /// <summary>
        /// player move event handler
        /// </summary>
        private void OnPlayerMove()
        {
            //
            // update description if location has already been visited
            //
            if (_player.LocationsVisited.Contains(_currentLocation))
            {
                _currentLocation.Description = _currentLocation.VisitedDescription;
            }

            //
            // update player stats when in new location
            //
            if (!_player.HasVisited(_currentLocation))
            {
                //
                // add location to list of visited locations
                //
                _player.LocationsVisited.Add(_currentLocation);

                // 
                // update experience points
                //
                _player.ExperiencePoints += _currentLocation.ModifyXP;
            }
            //
            // update the list of locations
            //
            UpdateAccessibleLocations();
            OnPropertyChanged(nameof(CurrentLocation));
        }

        /// <summary>
        /// update the accessible locations for the list box
        /// </summary>
        private void UpdateAccessibleLocations()
        {

            //
            // add all accessible locations to list
            //
            foreach (Location location in _gameMap.Locations)
            {
                if (location.Accessible == true)
                {
                    _accessibleLocations.Add(location);
                }
            }

            //
            // notify list box in view to update
            //
            OnPropertyChanged(nameof(AccessibleLocations));
        }

        /// <summary>
        /// add a new item to the players inventory
        /// </summary>
        /// <param name="selectedItem"></param>
        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }
        }

        /// <summary>
        /// remove item from the players inventory
        /// </summary>
        /// <param name="selectedItem"></param>
        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                OnPlayerPutDown(selectedGameItem);
            }
        }

        /// <summary>
        /// process events when a player picks up a new game item
        /// </summary>
        /// <param name="gameItem">new game item</param>
        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.ExperiencePoints += gameItem.ExperiencePoints;
            _player.TotalWealth += gameItem.Value;
        }

        /// <summary>
        /// process events when a player puts down a new game item
        /// </summary>
        /// <param name="gameItem">new game item</param>
        private void OnPlayerPutDown(GameItem gameItem)
        {
            _player.TotalWealth -= gameItem.Value;
        }

        /// <summary>
        /// process using an item in the player's inventory
        /// </summary>
        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                case Injector injector:
                    ProcessInjectorUse(injector);
                    break;
                case Relic relic:
                    ProcessRelicUse(relic);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// process the effects of using the relic
        /// </summary>
        /// <param name="potion">potion</param>
        private void ProcessRelicUse(Relic relic)
        {
            string message;

            switch (relic.UseAction)
            {
                case Relic.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationsByRelic(relic.Id);
                    _currentLocation.Description = relic.UseMessage;
                    break;
                case Relic.UseActionType.KILLPLAYER:
                    OnPlayerDies(relic.UseMessage);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// process the effects of using the potion
        /// </summary>
        /// <param name="potion">potion</param>
        private void ProcessInjectorUse(Injector injector)
        {
            _player.Cohesion += injector.CohesionChange;
            _player.Energy += injector.EnergyChange;
            _player.RemoveGameItemFromInventory(_currentGameItem);
        }

        /// <summary>
        /// process player dies with option to reset and play again
        /// </summary>
        /// <param name="message">message regarding player death</param>
        private void OnPlayerDies(string message)
        {
            string messagetext = message +
                "\n\nWould you like to play again?";

            string titleText = "Death";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuitApplication();
                    break;
            }
        }

        /// <summary>
        /// player chooses to exit game
        /// </summary>
        private void QuitApplication()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// player chooses to reset game
        /// </summary>
        private void ResetPlayer()
        {
            Environment.Exit(0);
        }


        #region GAME TIMER METHODS

        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

        /// <summary>
        /// game time event, publishes every 1 second
        /// </summary>
        public void GameTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += OnGameTimerTick;
            timer.Start();
        }

        /// <summary>
        /// game timer event handler
        /// 1) update mission time on window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGameTimerTick(object sender, EventArgs e)
        {
            _gameTime = DateTime.Now - _gameStartTime;
            MissionTimeDisplay = "Mission Time " + _gameTime.ToString(@"hh\:mm\:ss");
        }

        #endregion

        #endregion

        #region EVENTS



        #endregion
    }
}
