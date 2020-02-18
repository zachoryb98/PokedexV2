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
    /// Interaction logic for frmCollectedPokemon.xaml
    /// </summary>
    public partial class frmCollectedPokemon : Window
    {
        private string _pokedexRoles;
        private int UserID;
        PokemonManager _pokemonManager = new PokemonManager();
        Pokemon _pokemon = new Pokemon();
        public frmCollectedPokemon(int userID, string pokedexRoles)
        {
            this._pokedexRoles = pokedexRoles;
            this.UserID = userID;
            InitializeComponent();
            this.ShowDialog();
        }

        //Go home
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var PokedexList = new PokedexHome(UserID, _pokedexRoles);
            this.Close();
        }

        //Go to list of pokemon
        private void btnPokedeList_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var PokedexList = new frmDex(UserID, _pokedexRoles);
            this.Close();
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

        //Reset the values after clearing them and setting new datasource in another method
        private void ResetColumns()
        {
            dgMyPokemonList.Columns[0].Header = "Pokemon Number";
            dgMyPokemonList.Columns[1].Header = "Pokemon Name";
            dgMyPokemonList.Columns[2].Header = "Pokemon Region";
            dgMyPokemonList.Columns[3].Header = "Pokemon Type";
            dgMyPokemonList.Columns[4].Header = "Pokemon Type 2";
            dgMyPokemonList.Columns[0].Width = 200;
            dgMyPokemonList.Columns[1].Width = 200;
            dgMyPokemonList.Columns[2].Width = 200;
            dgMyPokemonList.Columns[3].Width = 200;
            dgMyPokemonList.Columns[4].Width = 185;
            dgMyPokemonList.Columns.RemoveAt(5);
        }

        //On load
        private void dgMyPokemonList_Loaded(object sender, RoutedEventArgs e)
        {
            btnAddPokemon.Visibility = Visibility.Visible;
            btnRemovePokemon.Visibility = Visibility.Hidden;
            dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyPokemon(UserID);
            ResetColumns();            
        }

        //Takes user back to pokedex list
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var PokedexList = new frmDex(UserID, _pokedexRoles);
            this.Close();
        }

        //Shiny pokemon
        private void btnShinies_Click(object sender, RoutedEventArgs e)
        {
            dgMyPokemonList.Columns.Clear();
            btnAddPokemon.Visibility = Visibility.Visible;
            btnRemovePokemon.Visibility = Visibility.Hidden;
            btnAddPokemon.IsEnabled = true;
            btnAddPokemon.Content = "Add Shiny Pokemon";
            btnRemovePokemon.Content = "Remove Shiny";
            dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyShinyPokemon(UserID);
            ResetColumns();
        }

        //Regional Variants
        private void btnRegionalVariants_Click(object sender, RoutedEventArgs e)
        {
            dgMyPokemonList.Columns.Clear();
            btnAddPokemon.Visibility = Visibility.Visible;
            btnRemovePokemon.Visibility = Visibility.Hidden;
            btnAddPokemon.IsEnabled = true;
            btnAddPokemon.Content = "Add Regional Variant";
            btnRemovePokemon.Content = "Remove Regional";
            dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyRegionalPokemon(UserID);
            ResetColumns();
        }

        //Alternate Versions
        private void btnAlternate_Click(object sender, RoutedEventArgs e)
        {
            dgMyPokemonList.Columns.Clear();
            btnAddPokemon.IsEnabled = true;
            btnAddPokemon.Visibility = Visibility.Visible;
            btnRemovePokemon.Visibility = Visibility.Hidden;
            btnAddPokemon.Content = "Add Alternate Version";
            btnRemovePokemon.Content = "Remove Alternate";
            dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyAlternatePokemon(UserID);
            ResetColumns();
        }

        //All pokemon normal and extra versions
        private void btnAllPokemon_Click(object sender, RoutedEventArgs e)
        {
            lblStatusMessage.Content = "Showing all Pokemon for current user";
            //Making proper buttons visible
            btnAddPokemon.Visibility = Visibility.Visible;
            btnRemovePokemon.Visibility = Visibility.Hidden;

            //Creating new lists
            List<Pokemon> pokemon = new List<Pokemon>();
            List<Pokemon> alternates = new List<Pokemon>();
            List<Pokemon> regionals = new List<Pokemon>();
            List<Pokemon> shinies = new List<Pokemon>();

            //Getting each type of pokemon
            pokemon = _pokemonManager.RetrieveMyPokemon(UserID);
            alternates = _pokemonManager.RetrieveMyAlternatePokemon(UserID);
            regionals = _pokemonManager.RetrieveMyRegionalPokemon(UserID);
            shinies = _pokemonManager.RetrieveMyShinyPokemon(UserID);

            //Getting each alternate in alternates
            foreach (Pokemon alternate in alternates)
            {
                pokemon.Add(alternate);
            }

            //Getting each regional variant in regionals
            foreach (Pokemon regional in regionals)
            {
                pokemon.Add(regional);
            }

            //Getting each shiny in shinies
            foreach (Pokemon shiny in shinies)
            {
                pokemon.Add(shiny);
            }

            //Setting the item source
            dgMyPokemonList.ItemsSource = pokemon;

            ResetColumns();

            //Enabling and disabling proper buttons
            btnAddPokemon.IsEnabled = false;
            btnRemovePokemon.IsEnabled = false;

        }

        private void btnNormalPokemon_Click(object sender, RoutedEventArgs e)
        {
            //Clear values and set new populate with new values (Normal Pokemon)
            dgMyPokemonList.Columns.Clear();
            btnAddPokemon.IsEnabled = true;
            btnAddPokemon.Visibility = Visibility.Visible;
            btnRemovePokemon.Visibility = Visibility.Hidden;
            btnAddPokemon.Content = "Add Pokemon";
            btnAddPokemon.Content = "Remove Pokemon";
            dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyPokemon(UserID);
            ResetColumns();
            lblStatusMessage.Content = "Showing regular pokemon for current user";
        }

        private void btnAddPokemon_Click(object sender, RoutedEventArgs e)
        {
            // Used for what type of list to add to
            string pokemonVariant = "Normal";
            if (btnAddPokemon.Content.Equals("Add Pokemon"))
            {
                //List of all normal pokemon
                List<Pokemon> normalPokemon = new List<Pokemon>();
                normalPokemon = _pokemonManager.RetrieveAllPokemon();

                //Add normal pokemon
                var PokedexList = new frmAddPokemonToList(normalPokemon, UserID, pokemonVariant);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyPokemon(UserID);
                ResetColumns();
                lblStatusMessage.Content = "Went to add pokemon";
            }
            // Add alternate Version
            else if (btnAddPokemon.Content.Equals("Add Alternate Version"))
            {
                //list of alternate pokemon
                List<Pokemon> alternatePokemon = new List<Pokemon>();
                alternatePokemon = _pokemonManager.RetrieveAllAlternateForms();
                //Used for setting which kind of pokemon to add to list
                pokemonVariant = "Alternate";
                //Add to alternateuserstore
                var PokedexList = new frmAddPokemonToList(alternatePokemon, UserID, pokemonVariant);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyAlternatePokemon(UserID);
                ResetColumns();
            }
            //Add mega
            else if (btnAddPokemon.Content.Equals("Add Mega Pokemon"))
            {
                //List of Mega pokemon
                List<Pokemon> alternatePokemon = new List<Pokemon>();
                alternatePokemon = _pokemonManager.RetrieveAllMega();
                //Used to acknowledge we want mega pokemon
                pokemonVariant = "Mega";
                //Add to alternateuserstore
                var PokedexList = new frmAddPokemonToList(alternatePokemon, UserID, pokemonVariant);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyMegaPokemon(UserID);
                ResetColumns();
            }
            //Add regional variant
            else if (btnAddPokemon.Content.Equals("Add Regional Variant"))
            {
                //List of regional variant pokemon
                List<Pokemon> regionalPokemon = new List<Pokemon>();
                regionalPokemon = _pokemonManager.RetrieveAllRegionals();
                //Used to know that we want to add a regional variant
                pokemonVariant = "Regional";
                //Add to REgionalList
                var PokedexList = new frmAddPokemonToList(regionalPokemon, UserID, pokemonVariant);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyRegionalPokemon(UserID);
                ResetColumns();
            }
            //Add Shiny
            else
            {
                //Only other type is Shiny so I create a new list of Shiny pokemon
                List<Pokemon> shinyPokemon = new List<Pokemon>();
                shinyPokemon = _pokemonManager.RetrieveAllShinies();
                pokemonVariant = "Shiny";
                // add shiny
                var PokedexList = new frmAddPokemonToList(shinyPokemon, UserID, pokemonVariant);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyShinyPokemon(UserID);
                ResetColumns();
            }
        }

        private void btnMegas_Click(object sender, RoutedEventArgs e)
        {
            //Reset list for mega pokemon
            dgMyPokemonList.Columns.Clear();
            btnAddPokemon.IsEnabled = true;
            btnAddPokemon.Visibility = Visibility.Visible;
            btnRemovePokemon.Visibility = Visibility.Hidden;
            btnAddPokemon.Content = "Add Mega";
            btnRemovePokemon.Content = "Remove Mega";
            dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyMegaPokemon(UserID);
            ResetColumns();
            lblStatusMessage.Content = "Showing all Mega Evolution Pokemon for current user.";
        }

        private void dgMyPokemonList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Double click to remove pokemon from list
            btnAddPokemon.Visibility = Visibility.Hidden;
            btnAddPokemon.IsEnabled = false;
            btnRemovePokemon.Visibility = Visibility.Visible;
            btnRemovePokemon.IsEnabled = true;
            lblStatusMessage.Content = "Select the remove button to remove a selected pokemon.";
        }

        private void btnRemovePokemon_Click(object sender, RoutedEventArgs e)
        {
            Pokemon selectedPokemon = new Pokemon();
            var selectedItem = dgMyPokemonList.SelectedItem;
            selectedPokemon = (Pokemon)selectedItem;
            lblStatusMessage.Content = "Removed " + _pokemon.PokemonName;

            //Remove regional variant
            if (btnRemovePokemon.Content.Equals("Remove Regional"))
            {
                _pokemonManager.RemoveRegionalPokemon(selectedPokemon.AlternatePokemonNumber, UserID);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyRegionalPokemon(UserID);
                ResetColumns();
            }
            //Remove Mega Variant
            else if (btnRemovePokemon.Content.Equals("Remove Mega"))
            {
                _pokemonManager.RemoveMegaPokemon(selectedPokemon.AlternatePokemonNumber, UserID);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyMegaPokemon(UserID);
                ResetColumns();
            }
            //Remove alternate version
            else if (btnRemovePokemon.Content.Equals("Remove Alternate"))
            {
                _pokemonManager.RemoveAlternatePokemon(selectedPokemon.AlternatePokemonNumber, UserID);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyAlternatePokemon(UserID);
                dgMyPokemonList.Columns[0].Header = "Pokemon Number";
                ResetColumns();
            }
            //Remove normal pokemon
            else if (btnRemovePokemon.Content.Equals("Remove Pokemon"))
            {
                _pokemonManager.RemovePokemon(selectedPokemon.PokemonNumber, UserID);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyPokemon(UserID);
                ResetColumns();
            }
            //Remove Shiny Variant
            else
            {
                _pokemonManager.RemoveShinyPokemon(selectedPokemon.AlternatePokemonNumber, UserID);
                dgMyPokemonList.ItemsSource = _pokemonManager.RetrieveMyShinyPokemon(UserID);
                ResetColumns();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Blocking these if user role is a normal user
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

        //Takes you to admin page
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var admin = new frmAdmin(UserID, _pokedexRoles);
            this.Close();
        }

        //Logs user out
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            this.Close();
        }
    }
}
