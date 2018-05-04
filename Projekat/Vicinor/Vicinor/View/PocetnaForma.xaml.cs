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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Vicinor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
   
    public sealed partial class PocetnaForma : Page
    {
        public PocetnaForma()
        {
            this.InitializeComponent();
        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            //LogIn korisnika
            //Otvaranje forme search for restaurants
            //SearchForRestaurants sfr = new SearchForRestaurants();
           Frame.Navigate(typeof(SearchRestaurants));
          

        }

        private void registerHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            //Otvaranje forme za registraciju korisnika
            this.Frame.Navigate(typeof(RegistracijaKorisnika));
        }

        private void continueHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            //Otvaranje forme search for restaurants
           this.Frame.Navigate(typeof(SearchRestaurants));
        }
    }
}
