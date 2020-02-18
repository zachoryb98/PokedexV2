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
    /// Interaction logic for frmUpdateUserPassword.xaml
    /// </summary>
    public partial class frmUpdateUserPassword : Window
    {
        private PokedexUser _pokedexUser = null;
        private IPokedexUserManager _pokedexUserManager = null;

        public frmUpdateUserPassword(PokedexUser pokedexUser, IPokedexUserManager pokedexUserManager)
        {
            InitializeComponent();
            _pokedexUser = pokedexUser;
            _pokedexUserManager = pokedexUserManager;
        }

        //Initiates Password change
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (pwdCurrentUserPassword.Password.Length < 7)
            {
                MessageBox.Show("Current password is incorrect. Try again.");
                pwdCurrentUserPassword.Password = "";
                pwdCurrentUserPassword.Focus();
                return;
            }
            if (pwdNewUserPassword.Password.Length < 7 ||
                pwdNewUserPassword.Password == pwdCurrentUserPassword.Password)
            {
                MessageBox.Show("New password is incorrect. Try again.");
                pwdNewUserPassword.Password = "";
                pwdNewUserPassword.Focus();
                return;
            }
            if (pwdRetypeUserPassword.Password != pwdNewUserPassword.Password)
            {
                MessageBox.Show("New Password and Retype must match.");
                pwdNewUserPassword.Password = "";
                pwdRetypeUserPassword.Password = "";
                pwdNewUserPassword.Focus();
                return;
            }
            try
            {
                if (_pokedexUserManager.UpdatePassword(_pokedexUser.PokedexUserID,
                    pwdNewUserPassword.Password.ToString(),
                    pwdCurrentUserPassword.Password.ToString()))
                {
                    MessageBox.Show("Password Updated");
                    this.DialogResult = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                this.DialogResult = false;
            }
        }
    }
}