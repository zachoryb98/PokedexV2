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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPokedex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _pokedexRoles;
        private PokedexUser _pokedexUser = null;
        private int _pokedexUserID = 0;

        private IPokedexUserManager _pokedexUserManager;

        public MainWindow()
        {
            InitializeComponent();            
            _pokedexUserManager = new PokedexUserManager();
            this.ShowDialog();
        }

        //Initiates login
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var userEmail = txtUserName.Text;
            var userPassword = pwdPassword.Password;

            if (btnLogin.Content.ToString() == "Logout")
            {
                _pokedexUser = null;
                
                //Make it open the new page

                // reset the login
                btnLogin.Content = "Login";
                txtUserName.Text = "";
                pwdPassword.Password = "";
                txtUserName.IsEnabled = true;
                pwdPassword.IsEnabled = true;
                txtUserName.Visibility = Visibility.Visible;
                pwdPassword.Visibility = Visibility.Visible;
                lblUserName.Visibility = Visibility.Visible;
                lblPassword.Visibility = Visibility.Visible;
                return;
            }

            if (userEmail.Length < 7 || userPassword.Length < 7)
            {
                //Display a message, always say user name or password bad 
                //so bad users aren't sure what is wrong
                MessageBox.Show("Invalid Username or Password.", "Login Failed.", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUserName.Text = "";
                pwdPassword.Password = "";
                txtUserName.Focus();
                return;
            }
            // try to login
            try
            {

                _pokedexUser = _pokedexUserManager.AuthenticatePokedexUser(userEmail, userPassword);
                string pokedexRoles = "";
                for (int i = 0; i < _pokedexUser.PokedexRoles.Count; i++)
                {
                    pokedexRoles += _pokedexUser.PokedexRoles[i];
                    if (i < _pokedexUser.PokedexRoles.Count - 1)
                    {
                        pokedexRoles += ", ";
                    }
                }

                _pokedexUserID = _pokedexUserManager.GetUserID(userEmail);

                string message = "Welcome, " + _pokedexUser.PokedexUserName;


                //lblStatusMessage.Content = message;

                if (pwdPassword.Password == "newuser")
                {
                    var updatePassword = new frmUpdateUserPassword(_pokedexUser, _pokedexUserManager);
                    if (updatePassword.ShowDialog() == false)
                    {
                        this.Visibility = Visibility.Hidden;
                        var pokedexHome = new PokedexHome(_pokedexUserID, pokedexRoles);
                        
                    }
                }
                else
                {
                    this.Visibility = Visibility.Hidden;
                    var pokedexHome = new PokedexHome(_pokedexUserID, pokedexRoles);
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bad Username or Password.",
                    "Login Failed" + "\n\n" + ex.InnerException.Message,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
