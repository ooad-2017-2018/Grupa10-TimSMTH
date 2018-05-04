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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Vicinor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminStartPage : Page
    {
        public AdminStartPage()
        {
            this.InitializeComponent();
        }

        private void adminListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sListBoxItem.IsSelected) { myFrame.Navigate(typeof(AdminStatistika)); }
            else if (upListBoxItem.IsSelected) { myFrame.Navigate(typeof(AdminUserOverview)); }
            else if (uoListBoxItem.IsSelected) { myFrame.Navigate(typeof(AdminUpdate)); }
        }

        private void hamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}

