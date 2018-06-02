using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Vicinor.View;
using Windows.Services.Maps;
using Windows.Devices.Geolocation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Vicinor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ucitajMapu();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            //Otvaramo Poctnu formu
            this.Frame.Navigate(typeof(UserStartPage));
        }

       
    private async void ucitajMapu()
        {
            // Start at Microsoft in Redmond, Washington.
            BasicGeoposition startLocation = new BasicGeoposition() { Latitude = 47.643, Longitude = -122.131 };

            // End at the city of Seattle, Washington.
            BasicGeoposition endLocation = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };

            // Get the route between the points.
            MapRouteFinderResult routeResult =
                  await MapRouteFinder.GetDrivingRouteAsync(
                  new Geopoint(startLocation),
                  new Geopoint(endLocation),
                  MapRouteOptimization.Time,
                  MapRouteRestrictions.None);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                System.Text.StringBuilder routeInfo = new System.Text.StringBuilder();

                // Display summary info about the route.
                routeInfo.Append("Total estimated time (minutes) = ");
                routeInfo.Append(routeResult.Route.EstimatedDuration.TotalMinutes.ToString());
                routeInfo.Append("\nTotal length (kilometers) = ");
                routeInfo.Append((routeResult.Route.LengthInMeters / 1000).ToString());

                // Display the directions.
                routeInfo.Append("\n\nDIRECTIONS\n");

                foreach (MapRouteLeg leg in routeResult.Route.Legs)
                {
                    foreach (MapRouteManeuver maneuver in leg.Maneuvers)
                    {
                        routeInfo.AppendLine(maneuver.InstructionText);
                    }
                }

                // Load the text box.
                tbOutputText.Text = routeInfo.ToString();
            }
            else
            {
                tbOutputText.Text =
                      "A problem occurred: " + routeResult.Status.ToString();
            }
        }
    }
}
