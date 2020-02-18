using PokedexDataObjects;
using PokedexLogicLayer;
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

namespace WPFPokedex
{
    /// <summary>
    /// Interaction logic for frmDex.xaml
    /// </summary>
    public partial class frmDex : Window
    {
        //Variables for the filter
        string region = " ";
        string type = " ";
        string type2 = " ";

        private string _pokedexRoles;
        private int UserID;
        PokemonManager _pokemonManager = new PokemonManager();
        public frmDex(int userID, string pokedexRoles)
        {
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

        //Already here
        private void btnPokedexList_Click(object sender, RoutedEventArgs e)
        {
            //do nothing
        }

        //Go to stats compare
        private void btnStatsCompare_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var StatsCompare = new frmStatsCompare(UserID, _pokedexRoles);
            this.Close();
        }

        //Go to location
        private void btnLocation_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var Location = new frmMyPokemon(UserID, _pokedexRoles);
            this.Close();
        }

        //Go to list of my pokemon
        private void BtnMyPokemon_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var myPokemon = new frmCollectedPokemon(UserID, _pokedexRoles);
            this.Close();
        }

        //Goes to page for pokemon
        private void dgPokedexList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = dgPokedexList.SelectedItem;
            var selectedPokemon = (Pokemon)selectedItem;
            var PokemonNumber = selectedPokemon.PokemonNumber;
            var newDexEntry = new frmPokedexPage(_pokemonManager, PokemonNumber - 1, UserID, _pokedexRoles);
        }

        //On load
        private void dgPokedexList_Loaded(object sender, RoutedEventArgs e)
        {
            dgPokedexList.ItemsSource = _pokemonManager.RetrieveAllPokemon();
            dgPokedexList.Columns[0].Header = "Pokemon Number";
            dgPokedexList.Columns[1].Header = "Pokemon Name";
            dgPokedexList.Columns[2].Header = "Pokemon Region";
            dgPokedexList.Columns[3].Header = "Pokemon Type";
            dgPokedexList.Columns[4].Header = "Pokemon Type 2";
            dgPokedexList.Columns[0].Width = 200;
            dgPokedexList.Columns[1].Width = 200;
            dgPokedexList.Columns[2].Width = 200;
            dgPokedexList.Columns[3].Width = 200;
            dgPokedexList.Columns[4].Width = 185;
            dgPokedexList.Columns.RemoveAt(5);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblStatusMessage.Content = "Viewing list of Pokemon.";
            //Create a new list of regions and add them to it
            List<string> Regions = new List<string>();
            Regions.Add(" ");
            Regions.Add("Kanto");
            Regions.Add("Johto");
            Regions.Add("Hoenn");
            Regions.Add("Sinnoh");
            Regions.Add("Unova");
            Regions.Add("Kalos");
            Regions.Add("Alola");
            cboRegion.ItemsSource = Regions;

            //Create a new list of pokemon types and populate combo boxes
            List<String> Types = new List<string>();
            Types.Add(" ");
            Types.Add("Normal");
            Types.Add("Fire");
            Types.Add("Water");
            Types.Add("Grass");
            Types.Add("Bug");
            Types.Add("Electric");
            Types.Add("Ice");
            Types.Add("Fighting");
            Types.Add("Poison");
            Types.Add("Ground");
            Types.Add("Flying");
            Types.Add("Psychic");
            Types.Add("Rock");
            Types.Add("Ghost");
            Types.Add("Dark");
            Types.Add("Dragon");
            Types.Add("Steel");
            Types.Add("Fairy");
            cboType.ItemsSource = Types;
            cboType2.ItemsSource = Types;

            //Disable based on user settings
            if (_pokedexRoles.Contains("Normal"))
            {
                btnLocation.IsEnabled = false;
                btnStatsCompare.IsEnabled = false;
                btnMyPokemon.IsEnabled = false;
            }
            else
            {
                btnLocation.IsEnabled = true;
                btnStatsCompare.IsEnabled = true;
                btnMyPokemon.IsEnabled = true;
            }
        }

        //Go to admin page
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var admin = new frmAdmin(UserID, _pokedexRoles);
            this.Close();
        }

        //Log user out
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            this.Close();
        }

        //Filter based on region selection changed
        private void cboRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            region = cboRegion.SelectedItem.ToString();
            filter();
        }

        //Filter based on type selection changed
        private void cboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type = cboType.SelectedItem.ToString();
            filter();
        }

        //Filter based on type2 selection changed
        private void cboType2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            type2 = cboType2.SelectedItem.ToString();
            filter();
        }

        private void RefreshList()
        {
            dgPokedexList.Columns[0].Header = "Pokemon Number";
            dgPokedexList.Columns[1].Header = "Pokemon Name";
            dgPokedexList.Columns[2].Header = "Pokemon Region";
            dgPokedexList.Columns[3].Header = "Pokemon Type";
            dgPokedexList.Columns[4].Header = "Pokemon Type 2";
            dgPokedexList.Columns[0].Width = 200;
            dgPokedexList.Columns[1].Width = 200;
            dgPokedexList.Columns[2].Width = 200;
            dgPokedexList.Columns[3].Width = 200;
            dgPokedexList.Columns[4].Width = 185;
            dgPokedexList.Columns.RemoveAt(5);
        }

        private void filter()
        {
            //If all are blank then get all pokemon
            if (region == " "
            && type == " "
            && type2 == " ")
            {
                dgPokedexList.ItemsSource = _pokemonManager.RetrieveAllPokemon();
                RefreshList();
                return;
            }
            //If all are not blank
            else if (region != " "
            && type != " "
            && type2 != " ")
            {
                dgPokedexList.ItemsSource = _pokemonManager.RetrievePokemonByTypeType2AndRegion(region,
                    type, type2);
                RefreshList();
                return;
            }
            //If region is blank
            else if (region == " "
            && type != " "
            && type2 != " ")
            {
                dgPokedexList.ItemsSource = _pokemonManager.RetrievePokemonByTypeAndType2(type, type2);
                RefreshList();
                return;
            }
            //If type is not blank
            else if (region != " "
            && type != " "
            && type2 == " ")
            {
                dgPokedexList.ItemsSource = _pokemonManager.RetrievePokemonByRegionAndType(region, type);
                RefreshList();
                return;
            }
            //If region and type 2 are not blank
            else if (region != " "
                    && type == " "
                    && type2 != " ")
            {
                dgPokedexList.ItemsSource = _pokemonManager.RetrievePokemonByRegionAndType2(region, type2);
                RefreshList();
                return;
            }
            //If region is not blank
            else if (region != " "
                       && type == " "
                       && type2 == " ")
            {
                dgPokedexList.ItemsSource = _pokemonManager.RetrievePokemonByRegion(region);
                RefreshList();
                return;
            }
            //If type is not null
            else if (region == " "
           && type != " "
           && type2 == " ")
            {
                dgPokedexList.ItemsSource = _pokemonManager.RetrievePokemonByType(type);
                RefreshList();
                return;
            }
            //If type 2 is not blank only
            else if (region == " "
                    && type == " "
                    && type2 != " ")
            {
                dgPokedexList.ItemsSource = _pokemonManager.RetrievePokemonByType2(type2);
                RefreshList();
                return;
            }
            else
            {
                //User should not be able to get here, but just in case
                MessageBox.Show("No results found, please try again");
            }
        }
    }
}





