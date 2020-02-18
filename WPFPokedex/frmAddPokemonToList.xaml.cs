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
    /// Interaction logic for frmAddPokemonToList.xaml
    /// </summary>
    public partial class frmAddPokemonToList : Window
    {
        int _userID;
        List<Pokemon> pokemonAdd = new List<Pokemon>();
        string _pokemonVariant;
        PokemonManager _pokemonManager = new PokemonManager();

        public frmAddPokemonToList(List<Pokemon> pokemon, int UserID, string pokemonVariant)
        {
            this._userID = UserID;
            this._pokemonVariant = pokemonVariant;
            this.pokemonAdd = pokemon;
            InitializeComponent();
            this.ShowDialog();
        }

        //On load event for the list of pokemon you can add
        private void dgAddPokemon_Loaded(object sender, RoutedEventArgs e)
        {
            //load list into datagrid
            dgAddPokemon.ItemsSource = pokemonAdd;
            dgAddPokemon.Columns[0].Header = "Pokemon Number";
            dgAddPokemon.Columns[1].Header = "Pokemon Name";
            dgAddPokemon.Columns[2].Header = "Pokemon Region";
            dgAddPokemon.Columns[0].Width = 200;
            dgAddPokemon.Columns[1].Width = 200;
            dgAddPokemon.Columns[2].Width = 200;
            dgAddPokemon.Columns.RemoveAt(4);
            dgAddPokemon.Columns.RemoveAt(3);
        }

        //Adds pokemon
        private void dgAddPokemon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = dgAddPokemon.SelectedItem;
            var selectedPokemon = (Pokemon)selectedItem;
            var pokemonNumber = selectedPokemon.PokemonNumber;
            var versionNumber = selectedPokemon.AlternatePokemonNumber;

            //Consider a switch here
            if (_pokemonVariant == "Normal")
            {
                _pokemonManager.StoreNormalPokemon(pokemonNumber, _userID);

                this.Close();
            }
            else if (_pokemonVariant == "Alternate")
            {

                _pokemonManager.StoreAlternatePokemon(versionNumber, _userID);
                this.Close();
            }
            else if (_pokemonVariant == "Regional")
            {
                _pokemonManager.StoreRegionalPokemon(versionNumber, _userID);
                this.Close();
            }
            else if (_pokemonVariant == "Mega")
            {
                _pokemonManager.StoreMegaPokemon(versionNumber, _userID);
                this.Close();
            }
            else
            {
                _pokemonManager.StoreShinyPokemon(versionNumber, _userID);
                this.Close();
            }
        }
    }
}
