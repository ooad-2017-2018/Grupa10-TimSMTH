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
using Windows.Devices.Geolocation;
using System.Threading;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Vicinor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchRestaurants : Page
    {
        public Geolocator geolocator = null;
        Geoposition position;
        public SearchRestaurants()
        {
            this.InitializeComponent();

            Initial();
           
        }
        public async void Initial()
        {
            bool b = await getLocationByGeolocatorAsync();
            if(b)
            radiusTextBox.Text = "Lat="+position.Coordinate.Point.Position.Latitude.ToString()+"Long:"+ position.Coordinate.Point.Position.Longitude.ToString();
        }

        private CancellationTokenSource _geolocationCancelationTokenSource = null;

        private async Task<bool> getLocationByGeolocatorAsync()
        {
            if (geolocator == null)
            {
                geolocator = new Geolocator();
            }

            bool boSuccess = false;

            //some preflight checks here
            if (geolocator.LocationStatus != PositionStatus.Disabled && geolocator.LocationStatus != PositionStatus.NotAvailable)
            {
                try
                {
                    // Get cancellation token 
                    _geolocationCancelationTokenSource = new CancellationTokenSource();
              
                    this.cancelGeolocationTimerAsync();

                     position = await geolocator.GetGeopositionAsync().AsTask();


                    boSuccess = true;
                }
                catch (Exception e) { 
                }
                finally
                {
                    _geolocationCancelationTokenSource = null;
                }
            }
            return boSuccess;
        }


        private async Task cancelGeolocationTimerAsync()
        {
            //delay should be less than 7sec (cause 7sec is the default timeout of the geolocator)
            //if a delay > 7sec is needed a timer with a value set higher than the value here should 
            //be set to the geolocator manually
            await Task.Delay(2000);
            if (_geolocationCancelationTokenSource != null)
            {
                _geolocationCancelationTokenSource.Cancel();
                _geolocationCancelationTokenSource = null;
            }
        }


        private void startSearchButton_Click(object sender, RoutedEventArgs e)
        {
            //Otvaranje forme za pretragu
            this.Frame.Navigate(typeof(StartSearch1));
        }

        private void favListButton_Click(object sender, RoutedEventArgs e)
        {
            //Otvaranje forme FavList
            this.Frame.Navigate(typeof(FavouritesList));
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            //Otvaranje forme za update profila korisnika
            this.Frame.Navigate(typeof(UpdateProfil));
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PocetnaForma));
        }
    }
}
