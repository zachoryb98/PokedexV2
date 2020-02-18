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
using Xceed.Wpf.Toolkit;

namespace WPFPokedex
{
    /// <summary>
    /// Interaction logic for frmPokedexPage.xaml
    /// </summary>
    public partial class frmPokedexPage : Window
    {
        private string _pokedexRoles;
        PokemonManager _pokemonManager;
        int _pokemonIndex;
        PokedexEntry _pokedexEntry;
        private int UserID;
        PokedexEntry evo1;
        PokedexEntry evo2;
        PokedexEntry evo3;
        PokedexEntry evo4;
        PokedexEntry evo5;
        PokedexEntry evo6;
        PokedexEntry evo7;
        PokedexEntry evo8;
        PokedexEntry evo9;

        public frmPokedexPage(PokemonManager pokemonManager, int pokemonIndex, int userID, string pokedexRoles)
        {

            InitializeComponent();
            this._pokedexRoles = pokedexRoles;
            this._pokemonManager = pokemonManager;
            this._pokemonIndex = pokemonIndex;
            this.UserID = userID;
            this.ShowDialog();
        }
        private void DisplayEntry()
        {
            //Displays the entry itself
            cboAlternates.Items.Clear();

            _pokedexEntry = _pokemonManager.GetPokedexEntry(_pokemonIndex);

            List<Pokemon> alternates = _pokemonManager.RetrieveAlternateVersions(_pokedexEntry.PokemonNumbers);

            List<int> stats = new List<int>();

            //adding the stats to the progress bars
            stats.Add(_pokedexEntry.PokemonHP);
            stats.Add(_pokedexEntry.PokemonAttack);
            stats.Add(_pokedexEntry.PokemonDefense);
            stats.Add(_pokedexEntry.PokemonSpecialAttack);
            stats.Add(_pokedexEntry.PokemonSpecialDefense);
            stats.Add(_pokedexEntry.PokemonSpeed);

            //Setting the content text
            lblPokemonName.Text = _pokedexEntry.PokemonNames.ToString();
            //They were not in the last games on the DS and there were not shiny versions
            if (lblPokemonName.Text == "Meltan" || lblPokemonName.Text == "Melmetal")
            {
                cboAlternates.Visibility = Visibility.Hidden;
            }
            else
            {
                cboAlternates.Visibility = Visibility.Visible;
            }
            lblPokemonNumberText.Text = _pokedexEntry.PokemonNumbers.ToString();
            lblType1.Text = _pokedexEntry.PokemonTypes.ToString();
            lblType2.Text = _pokedexEntry.PokemonTypes2.ToString();
            txtDexText.Text = _pokedexEntry.DexEntry.ToString();
            lblHeightContainer.Content = _pokedexEntry.PokemonHeight.ToString();
            lblWeightContainer.Content = _pokedexEntry.PokemonWeight.ToString();
            lblGenderContainer.Content = _pokedexEntry.PokemonGender.ToString();
            lblCategoryContainer.Content = _pokedexEntry.PokemonCategory.ToString();
            lblAbility1Container.Content = _pokedexEntry.PokemonAbility.ToString();
            lblAbility2Container.Content = _pokedexEntry.PokemonAbility2.ToString();
            cboAlternates.Items.Add(_pokedexEntry.PokemonNames.ToString());
            PokedexDataObjects.PokedexAppDetails.AppPath = AppContext.BaseDirectory;

            evo1 = _pokemonManager.GetPokedexEntry(Convert.ToInt32(_pokedexEntry.Evo1) - 1);
            imgEvo1.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + evo1.PokemonImage.ToString()));

            if (_pokedexEntry.Evo2 != "")
            {
                evo2 = _pokemonManager.GetPokedexEntry(Convert.ToInt32(_pokedexEntry.Evo2) - 1);
                imgEvo2.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + evo2.PokemonImage.ToString()));
            }
            else
            {
                imgEvo2.Source = null;
            }
            if (_pokedexEntry.Evo3 != "")
            {
                evo3 = _pokemonManager.GetPokedexEntry(Convert.ToInt32(_pokedexEntry.Evo3) - 1);
                imgEvo3.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + evo3.PokemonImage.ToString()));
            }
            else
            {
                imgEvo3.Source = null;
            }
            if (_pokedexEntry.Evo4 != "")
            {
                evo4 = _pokemonManager.GetPokedexEntry(Convert.ToInt32(_pokedexEntry.Evo4) - 1);
                imgEvo4.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + evo4.PokemonImage.ToString()));
            }
            else
            {
                imgEvo4.Source = null;
            }
            if (_pokedexEntry.Evo5 != "")
            {
                evo5 = _pokemonManager.GetPokedexEntry(Convert.ToInt32(_pokedexEntry.Evo5) - 1);
                imgEvo5.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + evo5.PokemonImage.ToString()));
            }
            else
            {
                imgEvo5.Source = null;
            }
            if (_pokedexEntry.Evo6 != "")
            {
                evo6 = _pokemonManager.GetPokedexEntry(Convert.ToInt32(_pokedexEntry.Evo6) - 1);
                imgEvo6.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + evo6.PokemonImage.ToString()));
            }
            else
            {
                imgEvo6.Source = null;
            }
            if (_pokedexEntry.Evo7 != "")
            {
                evo7 = _pokemonManager.GetPokedexEntry(Convert.ToInt32(_pokedexEntry.Evo7) - 1);
                imgEvo7.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + evo7.PokemonImage.ToString()));
            }
            else
            {
                imgEvo7.Source = null;
            }
            if (_pokedexEntry.Evo8 != "")
            {
                evo8 = _pokemonManager.GetPokedexEntry(Convert.ToInt32(_pokedexEntry.Evo8) - 1);
                imgEvo8.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + evo8.PokemonImage.ToString()));
            }
            else
            {
                imgEvo8.Source = null;
            }
            if (_pokedexEntry.Evo9 != "")
            {
                evo9 = _pokemonManager.GetPokedexEntry(Convert.ToInt32(_pokedexEntry.Evo9) - 1);
                imgEvo9.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + evo9.PokemonImage.ToString()));
            }
            else
            {
                imgEvo9.Source = null;
            }

            imgPokemon.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + _pokedexEntry.PokemonImage.ToString()));

            //Adding alternates to list
            foreach (Pokemon alternate in alternates)
            {
                cboAlternates.Items.Add(alternate.PokemonName);
            }

            //Setting the maximum of the progress bars
            prgHP.Maximum = 10;
            prgAttack.Maximum = 10;
            prgDefense.Maximum = 10;
            prgSpAtk.Maximum = 10;
            prgSpDef.Maximum = 10;
            prgSpeed.Maximum = 10;

            //Setting the actual values of the progress bars
            prgHP.Value = _pokedexEntry.PokemonHP;
            prgAttack.Value = _pokedexEntry.PokemonAttack;
            prgDefense.Value = _pokedexEntry.PokemonDefense;
            prgSpAtk.Value = _pokedexEntry.PokemonSpecialAttack;
            prgSpDef.Value = _pokedexEntry.PokemonSpecialDefense;
            prgSpeed.Value = _pokedexEntry.PokemonSpeed;

            //Setting the label values
            lblHP.Content = _pokedexEntry.PokemonHP.ToString();
            lblAttack.Content = _pokedexEntry.PokemonAttack.ToString();
            lblDefense.Content = _pokedexEntry.PokemonDefense.ToString();
            lblSpAtk.Content = _pokedexEntry.PokemonSpecialAttack.ToString();
            lblSpDef.Content = _pokedexEntry.PokemonSpecialDefense.ToString();
            lblSpeed.Content = _pokedexEntry.PokemonSpeed.ToString();
            disableNullButtons();
            lblStatusMessage.Content = "Viewing " + _pokedexEntry.PokemonNames;
        }

        //Go home
        private void btnPokedexHome_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

            var PokedexList = new PokedexHome(UserID, _pokedexRoles);
            this.Close();
        }

        //Goes to dex list
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

        //On load event handler
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayEntry();
            //Handles user settings
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

        //Gets next pokemon values
        private void btnNextPokemon_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex++;
            if (_pokemonIndex > _pokemonManager.RetrieveAllPokemon().Count - 1)
            {
                _pokemonIndex = 0;
            }
            DisplayEntry();
        }

        //Gets previous pokemon values
        private void btnPokemonPrevious_Click(object sender, RoutedEventArgs e)
        {
            _pokemonIndex--;
            if (_pokemonIndex < 0)
            {
                _pokemonIndex = _pokemonManager.RetrieveAllPokemon().Count - 1;
            }
            DisplayEntry();
        }

        //Exit
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Change to alternate values
        private void cboAlternates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboAlternates.SelectedItem == null)
            {
                //Do nothing
            }
            else
            {
                _pokedexEntry = _pokemonManager.GetPokedexEntry(_pokemonIndex);
                if (cboAlternates.SelectedIndex.Equals(0))
                {
                    DisplayEntry();
                }
                else
                {
                    PokedexEntry alternatePokemon = _pokemonManager.RetrieveAlternateVersionStats(cboAlternates.SelectedItem.ToString());

                    //Changes values to Alternate values
                    lblPokemonName.Text = alternatePokemon.PokemonNames.ToString();
                    lblType1.Text = alternatePokemon.PokemonTypes.ToString();
                    lblType2.Text = alternatePokemon.PokemonTypes.ToString();
                    txtDexText.Text = alternatePokemon.DexEntry.ToString();
                    lblHeightContainer.Content = alternatePokemon.PokemonHeight.ToString();
                    lblWeightContainer.Content = alternatePokemon.PokemonWeight.ToString();
                    lblGenderContainer.Content = alternatePokemon.PokemonGender.ToString();
                    lblCategoryContainer.Content = alternatePokemon.PokemonCategory.ToString();
                    lblAbility1Container.Content = alternatePokemon.PokemonAbility.ToString();
                    PokedexDataObjects.PokedexAppDetails.AppPath = AppContext.BaseDirectory;

                    imgPokemon.Source = new BitmapImage(new Uri(PokedexAppDetails.ImagePath + alternatePokemon.PokemonImage.ToString()));
                    if (alternatePokemon.PokemonAbility2 == null)
                    {
                        lblAbility2Container.Content = "";
                    }
                    else
                    {
                        lblAbility2Container.Content = alternatePokemon.PokemonAbility2.ToString();
                    }

                    prgHP.Maximum = 10;
                    prgAttack.Maximum = 10;
                    prgDefense.Maximum = 10;
                    prgSpAtk.Maximum = 10;
                    prgSpDef.Maximum = 10;
                    prgSpeed.Maximum = 10;

                    prgHP.Value = alternatePokemon.PokemonHP;
                    prgAttack.Value = alternatePokemon.PokemonAttack;
                    prgDefense.Value = alternatePokemon.PokemonDefense;
                    prgSpAtk.Value = alternatePokemon.PokemonSpecialAttack;
                    prgSpDef.Value = alternatePokemon.PokemonSpecialDefense;
                    prgSpeed.Value = alternatePokemon.PokemonSpeed;

                    lblHP.Content = alternatePokemon.PokemonHP.ToString();
                    lblAttack.Content = alternatePokemon.PokemonAttack.ToString();
                    lblDefense.Content = alternatePokemon.PokemonDefense.ToString();
                    lblSpAtk.Content = alternatePokemon.PokemonSpecialAttack.ToString();
                    lblSpDef.Content = alternatePokemon.PokemonSpecialDefense.ToString();
                    lblSpeed.Content = alternatePokemon.PokemonSpeed.ToString();

                }
            }
        }

        //Goes to admin page
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var admin = new frmAdmin(UserID, _pokedexRoles);
            this.Close();
        }

        //Logout button
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            this.Close();
        }

        //Takes user to selected pokemon image for the next 9 on click events
        private void btnEvo1_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex = evo1.PokemonNumbers - 1;
            DisplayEntry();
        }

        private void btnEvo2_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex = evo2.PokemonNumbers - 1;
            DisplayEntry();
        }

        private void btnEvo3_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex = evo3.PokemonNumbers - 1;
            DisplayEntry();
        }

        private void btnEvo4_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex = evo4.PokemonNumbers - 1;
            DisplayEntry();
        }

        private void btnEvo5_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex = evo5.PokemonNumbers - 1;
            DisplayEntry();
        }

        private void btnEvo6_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex = evo6.PokemonNumbers - 1;
            DisplayEntry();
        }

        private void btnEvo7_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex = evo7.PokemonNumbers - 1;
            DisplayEntry();
        }

        private void btnEvo8_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex = evo8.PokemonNumbers - 1;
            DisplayEntry();
        }

        private void btnEvo9_Click(object sender, RoutedEventArgs e)
        {
            cboAlternates.Items.Clear();
            _pokemonIndex = evo9.PokemonNumbers - 1;
            DisplayEntry();
        }

        //Disables buttons when pokemon doesn't have that evolution
        private void disableNullButtons()
        {
            if (_pokedexEntry.Evo2 == "")
            {
                btnEvo2.IsEnabled = false;
                btnEvo3.IsEnabled = false;
                btnEvo4.IsEnabled = false;
                btnEvo5.IsEnabled = false;
                btnEvo6.IsEnabled = false;
                btnEvo7.IsEnabled = false;
                btnEvo8.IsEnabled = false;
                btnEvo9.IsEnabled = false;
            }
            else
            {
                btnEvo2.IsEnabled = true;
            }
            if (_pokedexEntry.Evo3 == "")
            {
                btnEvo3.IsEnabled = false;
                btnEvo4.IsEnabled = false;
                btnEvo5.IsEnabled = false;
                btnEvo6.IsEnabled = false;
                btnEvo7.IsEnabled = false;
                btnEvo8.IsEnabled = false;
                btnEvo9.IsEnabled = false;
            }
            else
            {
                btnEvo3.IsEnabled = true;
            }
            if (_pokedexEntry.Evo4 == "")
            {
                btnEvo4.IsEnabled = false;
                btnEvo5.IsEnabled = false;
                btnEvo6.IsEnabled = false;
                btnEvo7.IsEnabled = false;
                btnEvo8.IsEnabled = false;
                btnEvo9.IsEnabled = false;
            }
            else
            {
                btnEvo4.IsEnabled = true;
            }
            if (_pokedexEntry.Evo5 == "")
            {
                btnEvo5.IsEnabled = false;
                btnEvo5.IsEnabled = false;
                btnEvo6.IsEnabled = false;
                btnEvo7.IsEnabled = false;
                btnEvo8.IsEnabled = false;
                btnEvo9.IsEnabled = false;
            }
            else
            {
                btnEvo5.IsEnabled = true;
            }
            if (_pokedexEntry.Evo6 == "")
            {
                btnEvo6.IsEnabled = false;
                btnEvo7.IsEnabled = false;
                btnEvo8.IsEnabled = false;
                btnEvo9.IsEnabled = false;
            }
            else
            {
                btnEvo6.IsEnabled = true;
            }
            if (_pokedexEntry.Evo7 == "")
            {
                btnEvo7.IsEnabled = false;
                btnEvo8.IsEnabled = false;
                btnEvo9.IsEnabled = false;
            }
            else
            {
                btnEvo7.IsEnabled = true;
            }
            if (_pokedexEntry.Evo8 == "")
            {
                btnEvo8.IsEnabled = false;
                btnEvo9.IsEnabled = false;
            }
            else
            {
                btnEvo8.IsEnabled = true;
            }
            if (_pokedexEntry.Evo9 == "")
            {
                btnEvo9.IsEnabled = false;
            }
            else
            {
                btnEvo9.IsEnabled = true;
            }
        }


    }
}
