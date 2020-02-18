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
    /// Interaction logic for frmStatsCompare.xaml
    /// </summary>
    public partial class frmStatsCompare : Window
    {
        private string _pokedexRoles;
        private int UserID;
        private Pokemon pokemon1;
        private Pokemon pokemon2;
        PokemonManager _pokemonManager = new PokemonManager();
        List<String> cboFill = new List<String>();
        PokedexEntry pokedexEntry1 = new PokedexEntry();
        PokedexEntry pokedexEntry2 = new PokedexEntry();
        int statsTotal1;
        int statsTotal2;

        public frmStatsCompare(int userID, string pokedexRoles)
        {
            this._pokedexRoles = pokedexRoles;
            this.UserID = userID;
            InitializeComponent();
            fillCbos();
            this.ShowDialog();
        }

        //Fills up combo boxes
        void fillCbos()
        {
            cboFill.Add("Pokemon");
            cboFill.Add("Shinies");
            cboFill.Add("Megas");
            cboFill.Add("Alternates");
            cboFill.Add("Regionals");
        }

        //Goes home
        private void btnPokedexHome_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var PokedexList = new PokedexHome(UserID, _pokedexRoles);
            this.Close();
        }

        //Goes to pokedex list
        private void btnPokedexList_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var PokedexList = new frmDex(UserID, _pokedexRoles);
            this.Close();
        }

        //Goes to stats comparison
        private void btnStatsCompare_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var StatsCompare = new frmStatsCompare(UserID, _pokedexRoles);
            this.Close();
        }

        //Goes to location page
        private void btnLocation_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var Location = new frmMyPokemon(UserID, _pokedexRoles);
            this.Close();
        }

        //Mouse Double click event
        private void dgPokemonList1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pokemon1 = (Pokemon)dgPokemonList1.SelectedItem;    
            statsTotal1 = pokedexEntry1.PokemonHP + pokedexEntry1.PokemonDefense + pokedexEntry1.PokemonDefense
            + pokedexEntry1.PokemonSpecialAttack + pokedexEntry1.PokemonSpeed;
            pokedexEntry1 = _pokemonManager.GetPokedexEntry(pokemon1.PokemonNumber);
            dgPokemonList1.IsEnabled = false;
            btnSelectionChange1.Visibility = Visibility.Visible;           
            if (dgPokemonList2.IsEnabled == false)
            {
                btnCompare.IsEnabled = true;
                btnBattle.IsEnabled = true;
            }
            if (cboPokemonVersion1.SelectedItem.ToString() == "Pokemon")
            {
                pokedexEntry1 = _pokemonManager.GetPokedexEntry(pokemon1.PokemonNumber);
            }
            else
            {
                pokedexEntry1 = _pokemonManager.RetrieveAlternateVersionStats(pokemon1.PokemonName);
            }
            barHP_1.Maximum = 10;
            barAttack_1.Maximum = 10;
            barDefense_1.Maximum = 10;
            barSpecialAttack_1.Maximum = 10;
            barSpecialDefense_1.Maximum = 10;
            barSpeed_1.Maximum = 10;
            barTotal_1.Maximum = 50;

            lblPkmnName1.Content = pokedexEntry1.PokemonNames.ToString();
            lblTypeHolder_1.Content = pokedexEntry1.PokemonTypes.ToString();
            lblType2Holder_1.Content = pokedexEntry1.PokemonTypes2.ToString();
            lblAbilityHolder_1.Content = pokedexEntry1.PokemonAbility.ToString();
            if (pokedexEntry1.PokemonAbility != null)
            {
                lblAbility2Holder_1.Content = pokedexEntry1.PokemonAbility.ToString();
            }
            barHP_1.Value = pokedexEntry1.PokemonHP;
            lblHPNum_1.Content = pokedexEntry1.PokemonHP;
            barAttack_1.Value = pokedexEntry1.PokemonAttack;
            lblAttackNum_1.Content = pokedexEntry1.PokemonAttack;
            barDefense_1.Value = pokedexEntry1.PokemonDefense;
            lblDefenseNum_1.Content = pokedexEntry1.PokemonDefense;
            barSpecialAttack_1.Value = pokedexEntry1.PokemonSpecialAttack;
            lblSpecialAttackNum_1.Content = pokedexEntry1.PokemonSpecialAttack;
            barSpecialDefense_1.Value = pokedexEntry1.PokemonSpecialDefense;
            lblSpecialDefenseNum_1.Content = pokedexEntry1.PokemonSpecialDefense;
            barSpeed_1.Value = pokedexEntry1.PokemonSpeed;
            lblSpeedNum_1.Content = pokedexEntry1.PokemonSpeed;
            barTotal_1.Value = pokedexEntry1.PokemonHP + pokedexEntry1.PokemonDefense + pokedexEntry1.PokemonDefense
            + pokedexEntry1.PokemonSpecialAttack + pokedexEntry1.PokemonSpeed;
            lblTotalNum_1.Content = pokedexEntry1.PokemonHP + pokedexEntry1.PokemonDefense + pokedexEntry1.PokemonDefense
            + pokedexEntry1.PokemonSpecialAttack + pokedexEntry1.PokemonSpeed;
            PokedexDataObjects.PokedexAppDetails.AppPath = AppContext.BaseDirectory;
            imgPokemon1.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + pokedexEntry1.PokemonImage.ToString()));
        }

        //Load event for pokemonList1
        private void dgPokemonList1_Loaded(object sender, RoutedEventArgs e)
        {
            
            dgPokemonList1.ItemsSource = _pokemonManager.RetrieveAllPokemon();
            dgPokemonList1.Columns[0].Header = "Pokemon Number";
            dgPokemonList1.Columns[1].Header = "Pokemon Name";
            dgPokemonList1.Columns[2].Header = "Pokemon Region";
            dgPokemonList1.Columns[3].Header = "Pokemon Type";
            dgPokemonList1.Columns[4].Header = "Pokemon Type2";           
            dgPokemonList1.Columns.RemoveAt(5);
            dgPokemonList1.Columns.RemoveAt(2);
            dgPokemonList1.Columns.RemoveAt(0);
            dgPokemonList1.Columns[0].Width = 155;
            dgPokemonList1.Columns[1].Width = 155;
            dgPokemonList1.Columns[2].Width = 155;
        }

        //Load event for pokemonList2
        private void dgPokemonList2_Loaded(object sender, RoutedEventArgs e)
        {
            dgPokemonList2.ItemsSource = _pokemonManager.RetrieveAllPokemon();
            dgPokemonList2.Columns[0].Header = "Pokemon Number";
            dgPokemonList2.Columns[1].Header = "Pokemon Name";
            dgPokemonList2.Columns[2].Header = "Pokemon Region";
            dgPokemonList2.Columns[3].Header = "Pokemon Type";
            dgPokemonList2.Columns[4].Header = "Pokemon Type2";          
            dgPokemonList2.Columns.RemoveAt(5);
            dgPokemonList2.Columns.RemoveAt(2);
            dgPokemonList2.Columns.RemoveAt(0);
            dgPokemonList2.Columns[0].Width = 155;
            dgPokemonList2.Columns[1].Width = 155;
            dgPokemonList2.Columns[2].Width = 155;
        }

        //Pokemon List 2 event
        private void dgPokemonList2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {            
            pokemon2 = (Pokemon)dgPokemonList2.SelectedItem;
            statsTotal2 = pokedexEntry2.PokemonHP + pokedexEntry2.PokemonDefense + pokedexEntry2.PokemonDefense
            + pokedexEntry2.PokemonSpecialAttack + pokedexEntry2.PokemonSpeed;
            dgPokemonList2.IsEnabled = false;
            btnSelectionChange2.Visibility = Visibility.Visible;
            if(dgPokemonList1.IsEnabled == false)
            {
                btnCompare.IsEnabled = true;
                btnBattle.IsEnabled = true;
            }            
            if(cboPokemonVersion2.SelectedItem.ToString() == "Pokemon")
            {
                pokedexEntry2 = _pokemonManager.GetPokedexEntry(pokemon2.PokemonNumber);
            }
            else
            {
                pokedexEntry2 = _pokemonManager.RetrieveAlternateVersionStats(pokemon2.PokemonName);
            }
            
            dgPokemonList2.IsEnabled = false;
            btnSelectionChange2.Visibility = Visibility.Visible;
            if (dgPokemonList2.IsEnabled == false)
            {
                btnCompare.IsEnabled = true;
            }
            barHP_2.Maximum = 10;
            barAttack_2.Maximum = 10;
            barDefense_2.Maximum = 10;
            barSpecialAttack_2.Maximum = 10;
            barSpecialDefense_2.Maximum = 10;
            barSpeed_2.Maximum = 10;
            barTotal_2.Maximum = 50;

            lblPkmnName2.Content = pokedexEntry2.PokemonNames.ToString();
            lblTypeHolder_2.Content = pokedexEntry2.PokemonTypes.ToString();
            lblType2Holder_2.Content = pokedexEntry2.PokemonTypes2.ToString();
            lblAbilityHolder_2.Content = pokedexEntry2.PokemonAbility.ToString();            
            lblAbility2Holder_2.Content = "";
            if (pokedexEntry2.PokemonAbility2 != null)
            {
                lblAbility2Holder_2.Content = pokedexEntry2.PokemonAbility2.ToString();
            }
            lblAbility2Holder_2.Content = pokedexEntry2.PokemonAbility2.ToString();
            barHP_2.Value = pokedexEntry2.PokemonHP;
            lblHPNum_2.Content = pokedexEntry2.PokemonHP;
            barAttack_2.Value = pokedexEntry2.PokemonAttack;
            lblAttackNum_2.Content = pokedexEntry2.PokemonAttack;
            barDefense_2.Value = pokedexEntry2.PokemonDefense;
            lblDefenseNum_2.Content = pokedexEntry2.PokemonDefense;
            barSpecialAttack_2.Value = pokedexEntry2.PokemonSpecialAttack;
            lblSpecialAttackNum_2.Content = pokedexEntry2.PokemonSpecialAttack;
            barSpecialDefense_2.Value = pokedexEntry2.PokemonSpecialDefense;
            lblSpecialDefenseNum_2.Content = pokedexEntry2.PokemonSpecialDefense;
            barSpeed_2.Value = pokedexEntry2.PokemonSpeed;
            lblSpeedNum_2.Content = pokedexEntry2.PokemonSpeed;
            barTotal_2.Value = pokedexEntry2.PokemonHP + pokedexEntry2.PokemonDefense + pokedexEntry2.PokemonDefense
            + pokedexEntry2.PokemonSpecialAttack + pokedexEntry2.PokemonSpeed;
            lblTotalNum_2.Content = pokedexEntry2.PokemonHP + pokedexEntry2.PokemonDefense + pokedexEntry2.PokemonDefense
            + pokedexEntry2.PokemonSpecialAttack + pokedexEntry2.PokemonSpeed;
            PokedexDataObjects.PokedexAppDetails.AppPath = AppContext.BaseDirectory;
            imgPokemon2.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + pokedexEntry2.PokemonImage.ToString()));

        }

        //Loaded event for combo box types
        private void cboPokemonVersion1_Loaded(object sender, RoutedEventArgs e)
        {
            cboPokemonVersion1.ItemsSource = cboFill;            
            cboPokemonVersion1.SelectedIndex = 0;
        }

        //Loaded event for combo box types
        private void cboPokemonVersion2_Loaded(object sender, RoutedEventArgs e)
        {            
            cboPokemonVersion2.ItemsSource = cboFill;
            cboPokemonVersion2.SelectedIndex = 0;
        }

        //Selection changed event
        private void cboPokemonVersion2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            String selectedValue = cboPokemonVersion2.SelectedItem.ToString();
            switch (selectedValue)
            {
                case "Pokemon":
                    dgPokemonList2.Columns.Clear();
                    dgPokemonList2.ItemsSource = _pokemonManager.RetrieveAllPokemon();
                    dgPokemonList2.Columns[0].Header = "Pokemon Number";
                    dgPokemonList2.Columns[1].Header = "Pokemon Name";
                    dgPokemonList2.Columns[2].Header = "Pokemon Region";
                    dgPokemonList2.Columns[3].Header = "Pokemon Type";
                    dgPokemonList2.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList2.Columns.RemoveAt(5);
                    dgPokemonList2.Columns.RemoveAt(2);
                    dgPokemonList2.Columns.RemoveAt(0);
                    dgPokemonList2.Columns[0].Width = 155;
                    dgPokemonList2.Columns[1].Width = 155;
                    dgPokemonList2.Columns[2].Width = 155;
                    break;
                case "Shinies":
                    dgPokemonList2.Columns.Clear();
                    dgPokemonList2.ItemsSource = _pokemonManager.RetrieveAllShinies();
                    dgPokemonList2.Columns[0].Header = "Pokemon Number";
                    dgPokemonList2.Columns[1].Header = "Pokemon Name";
                    dgPokemonList2.Columns[2].Header = "Pokemon Region";
                    dgPokemonList2.Columns[3].Header = "Pokemon Type";
                    dgPokemonList2.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList2.Columns.RemoveAt(5);
                    dgPokemonList2.Columns.RemoveAt(2);
                    dgPokemonList2.Columns.RemoveAt(0);
                    dgPokemonList2.Columns[0].Width = 155;
                    dgPokemonList2.Columns[1].Width = 155;
                    dgPokemonList2.Columns[2].Width = 155;
                    break;
                case "Megas":
                    dgPokemonList2.Columns.Clear();
                    dgPokemonList2.ItemsSource = _pokemonManager.RetrieveAllMega();
                    dgPokemonList2.Columns[0].Header = "Pokemon Number";
                    dgPokemonList2.Columns[1].Header = "Pokemon Name";
                    dgPokemonList2.Columns[2].Header = "Pokemon Region";
                    dgPokemonList2.Columns[3].Header = "Pokemon Type";
                    dgPokemonList2.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList2.Columns.RemoveAt(5);
                    dgPokemonList2.Columns.RemoveAt(2);
                    dgPokemonList2.Columns.RemoveAt(0);
                    dgPokemonList2.Columns[0].Width = 155;
                    dgPokemonList2.Columns[1].Width = 155;
                    dgPokemonList2.Columns[2].Width = 155;
                    break;
                case "Alternates":
                    dgPokemonList2.Columns.Clear();
                    dgPokemonList2.ItemsSource = _pokemonManager.RetrieveAllAlternateForms();
                    dgPokemonList2.Columns[0].Header = "Pokemon Number";
                    dgPokemonList2.Columns[1].Header = "Pokemon Name";
                    dgPokemonList2.Columns[2].Header = "Pokemon Region";
                    dgPokemonList2.Columns[3].Header = "Pokemon Type";
                    dgPokemonList2.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList2.Columns.RemoveAt(5);
                    dgPokemonList2.Columns.RemoveAt(2);
                    dgPokemonList2.Columns.RemoveAt(0);
                    dgPokemonList2.Columns[0].Width = 155;
                    dgPokemonList2.Columns[1].Width = 155;
                    dgPokemonList2.Columns[2].Width = 155;
                    break;
                case "Regionals":
                    dgPokemonList2.Columns.Clear();
                    dgPokemonList2.ItemsSource = _pokemonManager.RetrieveAllRegionals();
                    dgPokemonList2.Columns[0].Header = "Pokemon Number";
                    dgPokemonList2.Columns[1].Header = "Pokemon Name";
                    dgPokemonList2.Columns[2].Header = "Pokemon Region";
                    dgPokemonList2.Columns[3].Header = "Pokemon Type";
                    dgPokemonList2.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList2.Columns.RemoveAt(5);
                    dgPokemonList2.Columns.RemoveAt(2);
                    dgPokemonList2.Columns.RemoveAt(0);
                    dgPokemonList2.Columns[0].Width = 155;
                    dgPokemonList2.Columns[1].Width = 155;
                    dgPokemonList2.Columns[2].Width = 155;
                    break;
                default:
                    dgPokemonList2.Columns.Clear();
                    dgPokemonList2.ItemsSource = _pokemonManager.RetrieveAllPokemon();
                    dgPokemonList2.Columns[0].Header = "Pokemon Number";
                    dgPokemonList2.Columns[1].Header = "Pokemon Name";
                    dgPokemonList2.Columns[2].Header = "Pokemon Region";
                    dgPokemonList2.Columns[3].Header = "Pokemon Type";
                    dgPokemonList2.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList2.Columns.RemoveAt(5);
                    dgPokemonList2.Columns.RemoveAt(2);
                    dgPokemonList2.Columns.RemoveAt(0);
                    dgPokemonList2.Columns[0].Width = 155;
                    dgPokemonList2.Columns[1].Width = 155;
                    dgPokemonList2.Columns[2].Width = 155;
                    break;
            }
        }

        //Allows user to battle various types of pokemon
        private void cboPokemonVersion1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedValue = cboPokemonVersion1.SelectedItem.ToString();
            switch (selectedValue)
            {
                case "Pokemon":
                    dgPokemonList1.Columns.Clear();
                    dgPokemonList1.ItemsSource = _pokemonManager.RetrieveAllPokemon();
                    dgPokemonList1.Columns[0].Header = "Pokemon Number";
                    dgPokemonList1.Columns[1].Header = "Pokemon Name";
                    dgPokemonList1.Columns[2].Header = "Pokemon Region";
                    dgPokemonList1.Columns[3].Header = "Pokemon Type";
                    dgPokemonList1.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList1.Columns.RemoveAt(5);
                    dgPokemonList1.Columns.RemoveAt(2);
                    dgPokemonList1.Columns.RemoveAt(0);
                    dgPokemonList1.Columns[0].Width = 155;
                    dgPokemonList1.Columns[1].Width = 155;
                    dgPokemonList1.Columns[2].Width = 155;
                    break;
                case "Shinies":
                    dgPokemonList1.Columns.Clear();
                    dgPokemonList1.ItemsSource = _pokemonManager.RetrieveAllShinies();
                    dgPokemonList1.Columns[0].Header = "Pokemon Number";
                    dgPokemonList1.Columns[1].Header = "Pokemon Name";
                    dgPokemonList1.Columns[2].Header = "Pokemon Region";
                    dgPokemonList1.Columns[3].Header = "Pokemon Type";
                    dgPokemonList1.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList1.Columns.RemoveAt(5);
                    dgPokemonList1.Columns.RemoveAt(2);
                    dgPokemonList1.Columns.RemoveAt(0);
                    dgPokemonList1.Columns[0].Width = 155;
                    dgPokemonList1.Columns[1].Width = 155;
                    dgPokemonList1.Columns[2].Width = 155;
                    break;
                case "Megas":
                    dgPokemonList1.Columns.Clear();
                    dgPokemonList1.ItemsSource = _pokemonManager.RetrieveAllMega();
                    dgPokemonList1.Columns[0].Header = "Pokemon Number";
                    dgPokemonList1.Columns[1].Header = "Pokemon Name";
                    dgPokemonList1.Columns[2].Header = "Pokemon Region";
                    dgPokemonList1.Columns[3].Header = "Pokemon Type";
                    dgPokemonList1.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList1.Columns.RemoveAt(5);
                    dgPokemonList1.Columns.RemoveAt(2);
                    dgPokemonList1.Columns.RemoveAt(0);
                    dgPokemonList1.Columns[0].Width = 155;
                    dgPokemonList1.Columns[1].Width = 155;
                    dgPokemonList1.Columns[2].Width = 155;
                    break;
                case "Alternates":
                    dgPokemonList1.Columns.Clear();
                    dgPokemonList1.ItemsSource = _pokemonManager.RetrieveAllAlternateForms();
                    dgPokemonList1.Columns[0].Header = "Pokemon Number";
                    dgPokemonList1.Columns[1].Header = "Pokemon Name";
                    dgPokemonList1.Columns[2].Header = "Pokemon Region";
                    dgPokemonList1.Columns[3].Header = "Pokemon Type";
                    dgPokemonList1.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList1.Columns.RemoveAt(5);
                    dgPokemonList1.Columns.RemoveAt(2);
                    dgPokemonList1.Columns.RemoveAt(0);
                    dgPokemonList1.Columns[0].Width = 155;
                    dgPokemonList1.Columns[1].Width = 155;
                    dgPokemonList1.Columns[2].Width = 155;
                    break;
                case "Regionals":
                    dgPokemonList1.Columns.Clear();
                    dgPokemonList1.ItemsSource = _pokemonManager.RetrieveAllRegionals();
                    dgPokemonList1.Columns[0].Header = "Pokemon Number";
                    dgPokemonList1.Columns[1].Header = "Pokemon Name";
                    dgPokemonList1.Columns[2].Header = "Pokemon Region";
                    dgPokemonList1.Columns[3].Header = "Pokemon Type";
                    dgPokemonList1.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList1.Columns.RemoveAt(5);
                    dgPokemonList1.Columns.RemoveAt(2);
                    dgPokemonList1.Columns.RemoveAt(0);
                    dgPokemonList1.Columns[0].Width = 155;
                    dgPokemonList1.Columns[1].Width = 155;
                    dgPokemonList1.Columns[2].Width = 155;
                    break;
                default:
                    dgPokemonList1.Columns.Clear();
                    dgPokemonList1.ItemsSource = _pokemonManager.RetrieveAllPokemon();
                    dgPokemonList1.Columns[0].Header = "Pokemon Number";
                    dgPokemonList1.Columns[1].Header = "Pokemon Name";
                    dgPokemonList1.Columns[2].Header = "Pokemon Region";
                    dgPokemonList1.Columns[3].Header = "Pokemon Type";
                    dgPokemonList1.Columns[4].Header = "Pokemon Type2";
                    dgPokemonList1.Columns.RemoveAt(5);
                    dgPokemonList1.Columns.RemoveAt(2);
                    dgPokemonList1.Columns.RemoveAt(0);
                    dgPokemonList1.Columns[0].Width = 155;
                    dgPokemonList1.Columns[1].Width = 155;
                    dgPokemonList1.Columns[2].Width = 155;
                    break;
            }
        }

        //Opens Compare canvas
        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            canCompare.Visibility = Visibility.Visible;
            canSelect.Visibility = Visibility.Hidden;
            btnCompare.Visibility = Visibility.Hidden;
            btnCompare.IsEnabled = false;
            btnReset.Visibility = Visibility.Visible;
            btnReset.IsEnabled = true;
            btnSelectionChange1.Visibility = Visibility.Hidden;
            btnSelectionChange2.Visibility = Visibility.Hidden;
            btnBattle.Visibility = Visibility.Hidden;
        }

        //Resets page
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            canCompare.Visibility = Visibility.Hidden;
            canBattle.Visibility = Visibility.Hidden;
            canSelect.Visibility = Visibility.Visible;
            btnCompare.Visibility = Visibility.Visible;
            btnBattle.Visibility = Visibility.Visible;
            btnCompare.IsEnabled = false;
            btnReset.Visibility = Visibility.Hidden;
            btnReset.IsEnabled = false;
            btnBattle.IsEnabled = false;
            dgPokemonList1.IsEnabled = true;
            dgPokemonList2.IsEnabled = true;
        }

        //Allows user to change second pokemon
        private void btnSelectionChange2_Click(object sender, RoutedEventArgs e)
        {
            dgPokemonList2.IsEnabled = true;
            btnSelectionChange2.Visibility = Visibility.Hidden;
        }

        //Allows user to change first pokemon
        private void btnSelectionChange1_Click(object sender, RoutedEventArgs e)
        {
            dgPokemonList1.IsEnabled = true;
            btnSelectionChange1.Visibility = Visibility.Hidden;
        }

        //Takes user home
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var Home = new PokedexHome(UserID, _pokedexRoles);
            this.Close();
        }

        //Opens canvas for battle simulation
        private void btnBattle_Click(object sender, RoutedEventArgs e)
        {
            canBattle.Visibility = Visibility.Visible;
            btnBattle.Visibility = Visibility.Hidden;
            canSelect.Visibility = Visibility.Hidden;
            btnCompare.Visibility = Visibility.Hidden;
            btnCompare.IsEnabled = false;
            btnReset.Visibility = Visibility.Visible;
            btnReset.IsEnabled = true;
            btnSelectionChange1.Visibility = Visibility.Hidden;
            btnSelectionChange2.Visibility = Visibility.Hidden;
            btnCompare.Visibility = Visibility.Hidden;

            PokedexDataObjects.PokedexAppDetails.AppPath = AppContext.BaseDirectory;
            if (statsTotal1 > statsTotal2)
            {
                lblBattleStatus.Content = "WINNER!";
                lblWinnerName.Content = pokedexEntry1.PokemonNames.ToString();                                
                imgWinner.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + pokedexEntry1.PokemonImage.ToString()));
            }
            else if (statsTotal1 == statsTotal2)
            {
                lblBattleStatus.Content = "DRAW!";
                lblWinnerName.Content = "";
                imgWinner.Source = null;
            }
            else
            {
                lblBattleStatus.Content = "WINNER!";
                lblWinnerName.Content = pokedexEntry2.PokemonNames.ToString();
                imgWinner.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + pokedexEntry2.PokemonImage.ToString()));
            }

        }

        //Loaded Event
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

        //Goes to admin page
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var admin = new frmAdmin(UserID, _pokedexRoles);
            this.Close();
        }

        //Logs out
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            this.Close();
        }
    }
}
