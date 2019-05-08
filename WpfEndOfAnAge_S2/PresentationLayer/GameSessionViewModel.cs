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

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
        public string MessageDisplay
        {
            get { return _currentLocation.Description; }
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
                OnPropertyChanged(nameof(CurrentLocation));
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
            }
        }

        /// <summary>
        /// player move event handler
        /// </summary>
        private void OnPlayerMove()
        {
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
