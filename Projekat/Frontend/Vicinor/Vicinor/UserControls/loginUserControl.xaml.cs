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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Vicinor.View
{
    public sealed partial class loginUserControl : UserControl
    {
        public delegate void MyEventHandler(object source, EventArgs e);

        public event MyEventHandler onNavigateParentReadyAdminStartPage, onNavigateParentReadySearchForRestaurants;

        PocetnaFormaViewModel pvm;
        public loginUserControl()
        {
            pvm = new PocetnaFormaViewModel();
            this.InitializeComponent();

        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {

            //LogIn korisnika
            //Otvaranje forme search for restaurants
            //SearchForRestaurants sfr = new SearchForRestaurants();
            Boolean b1 = pvm.loginAdmin(textBox.Text, textBox1.Password).Result;
            Boolean b2 = pvm.loginUser(textBox.Text, textBox1.Password).Result;
            errorTextBlock.Visibility = Visibility.Collapsed;
            errorTextBlock.Text = "";
            if (b1)
            {
                onNavigateParentReadyAdminStartPage(this, null);
              
            }
            else if (b2)
            {
                onNavigateParentReadySearchForRestaurants(this, null);
            }
            else
            {
                //textBox1.Text = "Again";
                // prijava greske            
                errorTextBlock.Visibility = Visibility.Visible;
                errorTextBlock.Text = "Invalid username or password!";
            }
          
          
        }
    }
}
