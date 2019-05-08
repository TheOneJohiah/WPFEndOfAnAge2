using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEndOfAnAge_S1.PresentationLayer;
using WpfEndOfAnAge_S1.DataLayer;
using WpfEndOfAnAge_S1.Models;

namespace WpfEndOfAnAge_S1.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        bool _newPlayer = false;
        Player _player = new Player();
        PlayerSetupView _playerSetupView = null;
        Map _gameMap;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
            _gameMap = GameData.GameMap();
        }

        /// <summary>
        /// setup new or existing player
        /// </summary>
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();
                //
                // setup up game based player properties
                //
                _player.ExperiencePoints = 0;
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        /// <summary>
        /// create view model with data set
        /// </summary>
        private void InstantiateAndShowView()
        {
            //
            // instantiate the view model and initialize the data set
            //
            _gameSessionViewModel = new GameSessionViewModel(
                _player,
                _gameMap
                );
            
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);
            
            gameSessionView.DataContext = _gameSessionViewModel;
            
            gameSessionView.Show();

            //
            // dialog window is initially hidden to mitigate issue with
            // main window closing after dialog window closes
            //_playerSetupView.Close();
        }

    }

}
