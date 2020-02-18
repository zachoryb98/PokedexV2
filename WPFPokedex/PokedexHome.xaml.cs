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
    /// Interaction logic for PokedexHome.xaml
    /// </summary>
    public partial class PokedexHome : Window
    {
        private int UserID;
        private string _pokedexRoles;

        
        public PokedexHome(int userID, string pokedexRoles)
        {
            this._pokedexRoles = pokedexRoles;
            this.UserID = userID;
            InitializeComponent();
            this.ShowDialog();
        }

        //Goes Home
        private void btnPokedexHome_Click(object sender, RoutedEventArgs e)
        {
           //do nothing
        }

        //Goes to Dex view
        private void btnDex_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;      
            var PokedexList = new frmDex(UserID, _pokedexRoles);
            this.Close();
        }

        //Goes to stats compare
        private void btnStatsCompare_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var StatsCompare = new frmStatsCompare(UserID, _pokedexRoles);
            this.Close();
        }

        //Goes to location
        private void btnLocation_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var Location = new frmMyPokemon(UserID, _pokedexRoles);
            this.Close();
        }

        //Load event
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

            if (!_pokedexRoles.Contains("Admin"))
            {
                btnAdmin.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnAdmin.Visibility = Visibility.Visible;
            }
        }

        //Goes to admin
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var admin = new frmAdmin(UserID, _pokedexRoles);
            this.Close();
        }

        //Logs user out.
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            this.Close();
        }
    }
}
