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
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Vicinor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateProfil : Page
    {
        public UpdateProfil()
        {
            this.InitializeComponent();
        }

        async void messageDialog(String s)
        {
            var dialog = new MessageDialog(s);
            await dialog.ShowAsync();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

            //Otvaranje pocetne forme
            messageDialog("Update succesful");
            this.Frame.Navigate(typeof(SearchRestaurants));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            //Otvaranje pocetne forme
            messageDialog("Update canceled");
            this.Frame.Navigate(typeof(SearchRestaurants));
        }
    }
}
