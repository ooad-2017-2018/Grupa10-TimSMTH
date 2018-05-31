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
using System.Net.Http;
using Windows.Data.Json;
using Vicinor.Model;

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

        private List<Restoran> listaDobavljenih = null;

        public SearchRestaurants()
        {
            this.InitializeComponent();
            listaDobavljenih = new List<Restoran>();
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

                    await this.cancelGeolocationTimerAsync();

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


        private async void startSearchButton_Click(object sender, RoutedEventArgs e)
        {
            //Otvaranje forme za pretragu, dobivanje rezultata sa api-ja
            // liste Restorana

            if(radiusTextBox.Text == "")
            {
                radiusTextBox.Text = "UNESITE RADIUS U BROJEVIMA";
                return;
            }
            if(radiusTextBox.Text == "UNESITE RADIUS U BROJEVIMA")
            {
                radiusTextBox.Text = "1000";
                return;
            }

            var client = new HttpClient();

            string LONGITUDINALA ="0.0", LANGITUDINALA = "0.0";

            if(position != null)
            {
                LONGITUDINALA = position.Coordinate.Point.Position.Longitude.ToString();
                LANGITUDINALA = position.Coordinate.Point.Position.Latitude.ToString();
            }

            HttpResponseMessage response = await client.GetAsync(new Uri("https://maps.googleapis.com/maps/api/place/search/json?types=restaurant" 
                + "&location=" + LONGITUDINALA + "%2C" + LANGITUDINALA + "&radius=" + radiusTextBox.Text.ToString() 
                + "&sensor=false&key=AIzaSyBIl5KmMwk5NiP69tCPnhGZJ3CAr-ml65s"));

            var jsonString = await response.Content.ReadAsStringAsync();

            JsonObject root = JsonValue.Parse(jsonString).GetObject();

            JsonArray REzultati = root.GetNamedArray("results");

            for(uint i = 0; i < REzultati.Count; ++i)
            {
                JsonObject restoran = REzultati.GetObjectAt(i);

                Restoran novi = new Restoran();

                string name_ime_restorana = restoran.GetNamedString("name");
                string place_id_kao_deskripcija = restoran.GetNamedString("place_id");
                string adresa_kao_phone_number = restoran.GetNamedString("vicinity");

                novi.Name = name_ime_restorana;

                novi.PhoneNumber = adresa_kao_phone_number;

                novi.RestoranId = (int) i;

                novi.Description = place_id_kao_deskripcija;

                JsonArray objekatPhotosM = null; 

                try
                {
                    objekatPhotosM = restoran.GetNamedArray("photos");
                }catch(Exception)
                {
                }

                if (objekatPhotosM != null && objekatPhotosM.Count > 0)
                {
                    JsonObject objekatPhotos = objekatPhotosM.GetObjectAt(0);

                    string slikaReferenca = objekatPhotos.GetNamedString("photo_reference");

                    double MAX_HEIGHT = objekatPhotos.GetNamedNumber("height");

                    double MAX_WIDTH = objekatPhotos.GetNamedNumber("width");

                    novi.SlikaURL = "https://maps.googleapis.com/maps/api/place/photo?photoreference=" +
                        slikaReferenca + "&sensor=false&maxheight=" + MAX_HEIGHT.ToString() +
                        "&maxwidth=" + MAX_WIDTH.ToString() + "&key=AIzaSyBIl5KmMwk5NiP69tCPnhGZJ3CAr-ml65s";

                }
                else novi.SlikaURL = "";


                // dobavljanje lokacije

                JsonObject lokacija = null;

                try
                {
                    lokacija = restoran.GetNamedObject("geometry");

                    JsonObject lokacijav2 = lokacija.GetNamedObject("location");
                        
                    double longitude = lokacijav2.GetNamedNumber("lng");    // x

                    double latitude = lokacijav2.GetNamedNumber("lat");     // y

                    Lokacija novaLokacija = new Lokacija();

                    novaLokacija.X = longitude;

                    novaLokacija.Y = latitude;

                    novi.Location = novaLokacija;
                }
                catch (Exception) { }

                listaDobavljenih.Add(novi);
            }

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
