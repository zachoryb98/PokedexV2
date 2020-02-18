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
using PokedexDataObjects;
using PokedexLogicLayer;

namespace WPFPokedex
{
    /// <summary>
    /// Interaction logic for frmLocation.xaml
    /// </summary>
    public partial class frmMyPokemon : Window
    {
        private string _pokedexRoles;
        LocationManager _locationManager = new LocationManager();
        private int UserID;
        List<String> games = new List<string>();

        public frmMyPokemon(int userID, string pokedexRoles)
        {
            //List of games
            games.Add("Red");
            games.Add("Blue");
            games.Add("Green");
            games.Add("Yellow");
            games.Add("Gold");
            games.Add("Silver");
            games.Add("Crystal");
            games.Add("Ruby");
            games.Add("Saphire");
            games.Add("Emerald");
            games.Add("FireRed");
            games.Add("LeafGreen");
            games.Add("Diamond");
            games.Add("Pearl");
            games.Add("Platinum");
            games.Add("HeartGold");
            games.Add("SoulSilver");
            games.Add("Black");
            games.Add("White");
            games.Add("Black 2");
            games.Add("White 2");
            games.Add("X");
            games.Add("Y");
            games.Add("Sun");
            games.Add("Moon");
            games.Add("Ultra Sun");
            games.Add("Ultra Moon");
            games.Add("Sword");
            games.Add("Shield");
            this._pokedexRoles = pokedexRoles;
            this.UserID = userID;
            InitializeComponent();            
            this.ShowDialog();
        }

        //Go home
        private void btnPokedexHome_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var PokedexList = new PokedexHome(UserID, _pokedexRoles);
            this.Close();
        }

        //Go to the pokedex list
        private void btnPokedexList_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var PokedexList = new frmDex(UserID, _pokedexRoles);
            this.Close();
        }

        // Go to stats compare
        private void btnStatsCompare_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var StatsCompare = new frmStatsCompare(UserID, _pokedexRoles);
            this.Close();
        }

        //Go to location click
        private void btnLocation_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var Location = new frmMyPokemon(UserID, _pokedexRoles);
            this.Close();
        }

        //on load fill with list of games
        private void cboGames_Loaded(object sender, RoutedEventArgs e)
        {
            cboGames.ItemsSource = games;
            cboGames.SelectedIndex = 0;
        }

        //Resets the list of pokemon
        private void ResetList()
        {
            dgLocationList.Columns[0].Header = "Pokemon Name";
            dgLocationList.Columns[1].Header = "Location Description";
            dgLocationList.Columns[0].Width = 100;
        }


        //List on load fill
        private void dgLocationList_Loaded(object sender, RoutedEventArgs e)
        {
            dgLocationList.ItemsSource = _locationManager.RetrieveLocations(cboGames.SelectedIndex.ToString());
            ResetList();
        }

        //Goes to home
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var Home = new PokedexHome(UserID, _pokedexRoles);
            this.Close();
        }

        //Game selection change
        private void cboGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgLocationList.Columns.Clear();
            dgLocationList.ItemsSource = _locationManager.RetrieveLocations(cboGames.SelectedItem.ToString());
            ResetList();
            lblStatusMessage.Content = "Game Selected: Pokemon " + cboGames.SelectedItem.ToString();
        }

        //Sets text in textbox
        private void DgLocationList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = dgLocationList.SelectedItem;
            var selectedLocation = (Locations)selectedItem;
            var LocationText = selectedLocation.gameName;
            txtLocationText.Text = LocationText;
        }

        //Blocks user from stuff they don't have access to
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_pokedexRoles.Contains("Normal"))
            {
                btnLocation.IsEnabled = false;
                btnStatsCompare.IsEnabled = false;
            }
            else
            {
                btnLocation.IsEnabled = true;
                btnStatsCompare.IsEnabled = true;
            }
        }

        //Go to admin page
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var admin = new frmAdmin(UserID, _pokedexRoles);
            this.Close();
        }

        // Logout
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            this.Close();
        }
    }
}
