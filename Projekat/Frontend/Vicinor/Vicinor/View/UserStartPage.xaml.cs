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
using Vicinor.Forme;
using Vicinor.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Vicinor.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserStartPage : Page
    {
        int id_korisnika;  
        public UserStartPage()
        {
            this.InitializeComponent();
            id_korisnika = PocetnaFormaViewModel.KORISNIK_ID;
        }

        private void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fListBoxItem.IsSelected)
            {
                if (PocetnaForma.guestUser)
                {
                    DisplayGuestDialog();
                    return;
                }
                myFrame.Navigate(typeof(FavouritesList));
                userControlUser.Visibility = Visibility.Collapsed;


            }
            else if (srListBoxItem.IsSelected)
            {
                myFrame.Navigate(typeof(SearchRestaurants));
                userControlUser.Visibility = Visibility.Collapsed;


            }
            else if (upListBoxItem.IsSelected)
            {
                if (PocetnaForma.guestUser)
                {
                    DisplayGuestDialog();
                    return;
                }
                myFrame.Navigate(typeof(UpdateProfil));
                userControlUser.Visibility = Visibility.Collapsed;
               
            }

            else if (loListBoxItem.IsSelected)
            {
                DisplayLogOutDialog();
            }

        }

        private async void DisplayLogOutDialog()
        {
            ContentDialog logOutDialog = new ContentDialog()
            {
                Title = "LogOut",
                Content = "Are you sure you want to log out?",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "Cancel"
            };

            ContentDialogResult r = await logOutDialog.ShowAsync();
            if (r== ContentDialogResult.Primary)
            {
                //Otvaramo Poctnu formu
                this.Frame.Navigate(typeof(PocetnaForma));
            }
            else
            {          
                this.Frame.Navigate(typeof(UserStartPage));

            }
        }

        private async void DisplayGuestDialog()
        {
            ContentDialog guestDialog = new ContentDialog()
            {
                Title = "Message",
                Content = "This option is only available for registered users!",
                PrimaryButtonText = "Ok",
              
            };

            await guestDialog.ShowAsync();
            
        }

        private void hamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;


        }
    }
}
