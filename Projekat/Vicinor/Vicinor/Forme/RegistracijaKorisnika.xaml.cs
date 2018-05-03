using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
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
    public sealed partial class RegistracijaKorisnika : Page
    {
        public RegistracijaKorisnika()
        {
            this.InitializeComponent();
        }

        async void messageDialog(String s)
        {
            var dialog = new MessageDialog(s);
            await dialog.ShowAsync();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Povratak na pocetnu formu

            messageDialog("Registration canceled");
            this.Frame.Navigate(typeof(PocetnaForma));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //Otvaranje pocetne forme
            messageDialog("Registration succesful");
            this.Frame.Navigate(typeof(PocetnaForma));
        }
    }
}
