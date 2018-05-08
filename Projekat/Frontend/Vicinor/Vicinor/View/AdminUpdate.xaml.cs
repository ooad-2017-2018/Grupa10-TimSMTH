using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Vicinor.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Vicinor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminUpdate : Page
    {
        AdminUpdateViewModel auvm;
        String newUsername, newPassword, confirmPassword;
        Boolean changeUsername = false, changePassword = false;
        public AdminUpdate()
        {
            auvm = new AdminUpdateViewModel();
            this.InitializeComponent();
            newUsernameTextBox.Visibility = Visibility.Collapsed;
            newUsernameTextBlock.Visibility = Visibility.Collapsed;
            newPasswordTextBlock.Visibility = Visibility.Collapsed;
            newPasswordTextBox.Visibility = Visibility.Collapsed;
            confirmPasswordTextBlock.Visibility = Visibility.Collapsed;
            confirmPasswordTextBox.Visibility = Visibility.Collapsed;
            errorTextBox.Visibility = Visibility.Collapsed;
            String u = PocetnaFormaViewModel.getUsernameG();
            String p = PocetnaFormaViewModel.getPasswordG();
            if (u!= null)
            usernameTextBox.Text = u;
            if (p != null)
            passwordTextBox.Text = p;

        }

        private void changeUsernameHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            newUsernameTextBox.Visibility = Visibility.Visible;
            newUsernameTextBlock.Visibility = Visibility.Visible;
            changeUsername = true;
        }

        private void changePasswordHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            newPasswordTextBlock.Visibility = Visibility.Visible;
            newPasswordTextBox.Visibility = Visibility.Visible;
            confirmPasswordTextBlock.Visibility = Visibility.Visible;
            confirmPasswordTextBox.Visibility = Visibility.Visible;
            changePassword = true;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            newUsername = newUsernameTextBox.Text.ToString();
            newPassword = newPasswordTextBox.Text.ToString();
            confirmPassword = confirmPasswordTextBox.Text.ToString();

            //Password dozvoljena samo slova, brojevi i _, mora imati barem jedno veliko slovo i jedan broj, min duzina 6
            //Username dozvoljena samo mala slova, brojevi i _, mora biti jedinstven,  min duzina 6

            //Validacija promjena

            //Validiraj username
            if (changeUsername)
            {
                if (!auvm.validateUsernameLength(newUsername))
                {
                    errorTextBox.Visibility = Visibility.Visible;
                    errorTextBox.Text = "Username must contain atleast 6 characters!";
                    return;
                }
                if (!auvm.validateUsernameContent(newUsername))
                {
                    errorTextBox.Visibility = Visibility.Visible;
                    errorTextBox.Text = "Username must contain atleast one number! Username can contain only lower case letters, numbers and '_'. ";
                    return;
                }

                if (!auvm.validateUsernameContent(newUsername))
                {
                    errorTextBox.Visibility = Visibility.Visible;
                    errorTextBox.Text = "Password must contain atleast one number and one upper case letter! Only numbers, letters and '_' are allowed.";
                    return;
                }

                usernameTextBox.Text = newUsernameTextBox.Text.ToString();

    
            }


            //Validacija passworda
            if (changePassword)
            {
                if (!auvm.validatePasswordLength(newPassword))
                {
                    errorTextBox.Visibility = Visibility.Visible;
                    errorTextBox.Text = "Password must contain atleast 6 characters!";
                    return;
                }


                if (!auvm.validatePasswordConfirmPassword(newPassword, confirmPassword))
                {
                    errorTextBox.Visibility = Visibility.Visible;
                    errorTextBox.Text = "New password is not equal to Confirm password!";
                    return;
                }
                errorTextBox.Text = "";
                errorTextBox.Visibility = Visibility.Collapsed;
                passwordTextBox.Text = newPasswordTextBox.Text.ToString();
            }

            //Unos u bazu



            //Sve uredu, uspješan unos
            errorTextBox.Visibility = Visibility.Collapsed;         
            newUsernameTextBox.Visibility = Visibility.Collapsed;
            newUsernameTextBlock.Visibility = Visibility.Collapsed;
            newPasswordTextBlock.Visibility = Visibility.Collapsed;
            newPasswordTextBox.Visibility = Visibility.Collapsed;
            confirmPasswordTextBlock.Visibility = Visibility.Collapsed;
            confirmPasswordTextBox.Visibility = Visibility.Collapsed;

            newUsernameTextBox.Text = "";
            newPasswordTextBox.Text = "";
            confirmPasswordTextBox.Text = "";

            changePassword = false;
            changeUsername = false;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            newUsernameTextBox.Visibility = Visibility.Collapsed;
            newUsernameTextBlock.Visibility = Visibility.Collapsed;
            newPasswordTextBlock.Visibility = Visibility.Collapsed;
            newPasswordTextBox.Visibility = Visibility.Collapsed;
            confirmPasswordTextBlock.Visibility = Visibility.Collapsed;
            confirmPasswordTextBox.Visibility = Visibility.Collapsed;
            changePassword = false;
            changeUsername = false;
        }
    }
}
