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
    /// Interaction logic for frmAddEditUser.xaml
    /// </summary>
    public partial class frmAddEditUser : Window
    {

        private PokedexUser _user = null;
        int UserID;
        private IPokedexUserManager _userManager = null;
        private bool _addMode = false;
       
        public frmAddEditUser(IPokedexUserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _addMode = true;
        }


        public frmAddEditUser(PokedexUser user, IPokedexUserManager userManager, int _userID)
        {
            InitializeComponent();
            _user = user;
            UserID = _userID;
            _userManager = userManager;
        }

        //Goes back to Admin page
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        //Saves changes
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // error checks
            if (txtUserName.Text == "")
            {
                MessageBox.Show("You must enter a first name.");
                txtUserName.Focus();
                return;
            }

            if (!(txtEmail.Text.ToString().Length > 6
                  && txtEmail.Text.ToString().Contains("@")
                  && txtEmail.Text.ToString().Contains(".")))
            {
                MessageBox.Show("You must enter a valid email address.");
                txtEmail.Focus();
                return;
            }

            PokedexUser newUser = new PokedexUser()
            {
                PokedexUserName = txtUserName.Text.ToString(),
                Email = txtEmail.Text.ToString(),
                Active = (bool)chkActive.IsChecked
            };

            if (_addMode)
            {
                try
                {
                    if (_userManager.AddUser(newUser))
                    {
                        this.DialogResult = false;
                        this.Close();
                    }
                    try
                    {
                        lstAssigned.ItemsSource = _userManager.RetrieveUserRoles(_user.PokedexUserID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n"
                        + ex.InnerException.Message);
                }
            }
            else
            {
                try
                {
                    if (_userManager.EditUser(_user, newUser))
                    {
                        // success
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        throw new ApplicationException("Data not Saved.",
                            new ApplicationException("User may no longer exist.")); ;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n"
                        + ex.InnerException.Message);
                }
            }
        }

        //Actually enables editing.
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(txtUserID.Text) == UserID)
            {
                MessageBox.Show("User cannot change own settings");
            }
            else
            {
                SetEditMode();
            }

        }

        //Changes assigned roles
        private void lstAssigned_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_addMode || lstAssigned.SelectedItems.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Are you sure?", "Change Role Assignment", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                try
                {
                    if (_userManager.DeleteUserRole(_user.PokedexUserID, lstAssigned.SelectedItem.ToString()))
                    {
                        fillRoles();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);
                }
            }
        }

        //Changes unassigned roles
        private void lstUnassigned_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_addMode || lstUnassigned.SelectedItems.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Are you sure?", "Change Role Assignment", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                try
                {
                    if (_userManager.AddUserRole(_user.PokedexUserID, lstUnassigned.SelectedItem.ToString()))
                    {
                        fillRoles();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);
                }
            }
        }

        //Activates/deactivates users
        private void chkActive_Click(object sender, RoutedEventArgs e)
        {
            string caption = (bool)chkActive.IsChecked ? "Reactivate Employee" :
                            "Deactivate Employee";
            if (MessageBox.Show("Are you sure?", caption, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                chkActive.IsChecked = !(bool)chkActive.IsChecked;
                return;
            }
            try
            {
                _userManager.setActiveUserState((bool)chkActive.IsChecked, _user.PokedexUserID);
                this.DialogResult = true;
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        //Fills roles
        private void fillRoles()
        {
            try
            {
                var eRoles = _userManager.RetrieveUserRoles(_user.PokedexUserID);
                lstAssigned.ItemsSource = eRoles;
                var roles = _userManager.RetrieveUserRoles();
                for (int i = 0; i < roles.Count; i++)
                {
                    foreach (string r in eRoles)
                    {
                        roles.Remove(r);
                    }
                    lstUnassigned.ItemsSource = roles;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Enables editing
        private void SetEditMode()
        {
            txtUserName.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            chkActive.IsEnabled = true;
            lstAssigned.IsEnabled = true;
            lstUnassigned.IsEnabled = true;
            btnEdit.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Visible;
            txtUserName.Focus();
        }

        //On load event
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_addMode == false)
            {
                txtUserID.Text = _user.PokedexUserID.ToString();
                txtUserName.Text = _user.PokedexUserName;
                txtEmail.Text = _user.Email;
                chkActive.IsChecked = _user.Active;
                lstAssigned.IsEnabled = false;
                lstUnassigned.IsEnabled = false;
                fillRoles();
            }
            else
            {
                SetEditMode();
                chkActive.IsChecked = true;
                chkActive.IsEnabled = false;
                lstAssigned.IsEnabled = false;
                lstUnassigned.IsEnabled = false;
            }
        }
    }
}
