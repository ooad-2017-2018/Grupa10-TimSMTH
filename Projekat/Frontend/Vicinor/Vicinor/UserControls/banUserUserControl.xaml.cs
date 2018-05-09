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
using Windows.UI.Popups;
using Vicinor.ViewModel;
using Vicinor.Model;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Vicinor.UserControls
{
    public sealed partial class banUserUserControl : UserControl
    {
        AdminUserOverviewViewModel auov;
    
        public banUserUserControl()
        {
            auov = new AdminUserOverviewViewModel();
            this.InitializeComponent();
            Initiale();
        }


        public async void Initiale()
        {
            bool i = await auov.Initial();
        
        }

        private async void banButton_Click_1(object sender, RoutedEventArgs e)
        {
            String a = "";
            if (usernameAusoSuggestBox.Text != null)
            {
                a = usernameAusoSuggestBox.Text.ToString();
            }
            bool banovan = await auov.banujUsera(a);
            if (banovan)
            {
                var dialog = new MessageDialog("Uspješno banovan korisnik!");
                await dialog.ShowAsync();
            }
            Initiale();
        }

        private async void unbanButton_Click_1(object sender, RoutedEventArgs e)
        {
            String a = "";
            if (usernameAusoSuggestBox.Text != null)
            {
                a = usernameAusoSuggestBox.Text.ToString();
            }
            bool unbanovan = await auov.unbanujUsera(a);
            if (unbanovan)
            {
                var dialog = new MessageDialog("Uspješno unbanovan korisnik!");
                await dialog.ShowAsync();
            }
            Initiale();
        }
    }
}
