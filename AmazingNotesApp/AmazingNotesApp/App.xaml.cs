using AmazingNotesApp.Models;
using AmazingNotesApp.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmazingNotesApp
{
    public partial class App : Application
    {
        public static ObservableCollection<Item> Items = new ObservableCollection<Item>();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListItemsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
