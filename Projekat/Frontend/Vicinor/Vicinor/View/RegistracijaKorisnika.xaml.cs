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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Vicinor.Model;
using Vicinor.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Vicinor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaKorisnika : Page
    {
        RegistracijaKorisnikaViewModel rkvm;
        public RegistracijaKorisnika()
        {
            this.InitializeComponent();
            rkvm = new RegistracijaKorisnikaViewModel();
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

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            Boolean b = await rkvm.Registruj(Password.Text, Username.Text, FirstName.Text, LastName.Text, Email.Text, false, DateOfBirth.Date.DateTime, null);
            if (b) {
                messageDialog("Registration succesful");
                this.Frame.Navigate(typeof(PocetnaForma));
            }
        }
    }
}
