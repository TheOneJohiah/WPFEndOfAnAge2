using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfEndOfAnAge_S1.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            //InitializeWindowTheme();

            InitializeComponent();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TBOutput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBOutput.ScrollToEnd();
        }

        private void AncientButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveToAncientLab();
        }

        private void HometownButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveToHometown();
        }

        private void SkeetalaButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveToSkeetala();
        }

        private void BayButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveToBay();
        }

        private void FortButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveToFortress();
        }

        private void NifarraButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveToNifarra();
        }

        private void KefanaButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveToKefana();
        }

        private void AirshipButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveToSOFP();
        }

        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.AddItemToInventory();
            }
        }

        private void PutDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.RemoveItemFromInventory();
            }
        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnUseGameItem();
            }
        }

        private void EquipButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.EquipGameItem();
            }
        }
    }
}
