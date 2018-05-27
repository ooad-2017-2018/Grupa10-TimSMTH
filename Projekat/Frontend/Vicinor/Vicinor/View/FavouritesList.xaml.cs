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
using Vicinor.Model;
using Vicinor.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Vicinor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FavouritesList : Page
    {
        private List<Restoran> dRestorani;

        int korisnik_id;
        FavouritesListViewModel flvm;
        public FavouritesList()
        {
            this.InitializeComponent();
            korisnik_id = PocetnaFormaViewModel.KORISNIK_ID;
            flvm = new FavouritesListViewModel();
            Data_Loaded();
        }

        private async void Data_Loaded()
        {
             dRestorani = await flvm.dobaviRestorane(korisnik_id);
        }

    }
}
