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
    /// Interaction logic for frmAdmin.xaml
    /// </summary>
    public partial class frmAdmin : Window
    {
        private int UserID;
        private string _pokedexRoles;
        PokedexUserManager _userManager = new PokedexUserManager();
        public frmAdmin(int userID, string pokedexRoles)
        {
            this._pokedexRoles = pokedexRoles;
            this.UserID = userID;
            InitializeComponent();
            this.ShowDialog();
        }

        //Opens edit user screen
        private void dgUserList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            lblStatusMessage.Content = "Went to edit User";
            PokedexUser selectedUser = (PokedexUser)dgUserList.SelectedItem;
            var userWindow = new frmAddEditUser(selectedUser, _userManager, UserID);
            if (userWindow.ShowDialog() == true)
            {                
                refreshUserList();                
            }
            
        }

        //On load event
        private void dgUserList_Loaded(object sender, RoutedEventArgs e)
        {
            refreshUserList();
            lblStatusMessage.Content = "User List Loaded";
        }

        // Go home
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var PokedexList = new PokedexHome(UserID, _pokedexRoles);
            this.Close();
        }

        //Goes to PokedexList
        private void btnPokedeList_Click(object sender, RoutedEventArgs e)
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

        //Already here
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            //Do Nothing
        }
        //Logs user out
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            this.Close();
        }
        //Will refresh the list based on active\inactive
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            refreshUserList();
            if (chkActive.IsChecked == true)
            {
                lblStatusMessage.Content = "Switched to view of Active";
            }
            else
            {
                lblStatusMessage.Content = "Switched to view of Inactive";
            }
        }

        //Method called by Checkbox_Click
        private void refreshUserList()
        {
            dgUserList.ItemsSource = _userManager.RetrieveUserListByActive((bool)chkActive.IsChecked);
            dgUserList.Columns[0].Header = "User ID";
            dgUserList.Columns[1].Header = "User Name";
            dgUserList.Columns[2].Header = "Email";
            dgUserList.Columns[0].Width = 300;
            dgUserList.Columns[1].Width = 350;
            dgUserList.Columns[2].Width = 350;
            dgUserList.Columns.RemoveAt(3);
        }

        //Goes to add new user
        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            lblStatusMessage.Content = "Went to add User.";
            var userWindow = new frmAddEditUser(_userManager);
            if (userWindow.ShowDialog() == true)
            {                
                dgUserList.ItemsSource = _userManager.RetrieveUserListByActive();
            }
            
        }
    }
}
