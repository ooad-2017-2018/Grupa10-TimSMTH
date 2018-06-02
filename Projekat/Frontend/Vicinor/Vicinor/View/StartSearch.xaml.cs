using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Vicinor.Model;
using Vicinor.ViewModel;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Vicinor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartSearch1 : Page
    {
        public List<Restoran> dRestorani;
        StartSearchViewModel ssvm;
        public StartSearch1()
        {
            this.InitializeComponent();

            dRestorani = new List<Restoran>();
            dRestorani = SearchRestaurants.listaDobavljenih;
            //   flip.ItemsSource = dRestorani;
            ssvm = new StartSearchViewModel();

        }

        /*private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(PocetnaForma));
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(UpdateProfil));
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(SearchRestaurants));
        }

        private void favListButton_Click(object sender, RoutedEventArgs e)
        {
            //Otvaranje forme za registraciju korisnika
            this.Frame.Navigate(typeof(FavouritesList));
        }*/

        private void flip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void star1Button_Click(object sender, RoutedEventArgs e)
        {
            Restoran r = dRestorani[flip.SelectedIndex];
            ssvm.AddToFavourite(r);

        }

        private void routeButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(PrikazOdabranogRestorana));
        }
    }
}
