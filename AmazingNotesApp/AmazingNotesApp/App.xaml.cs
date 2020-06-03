using AmazingNotesApp.DataAccess;
using AmazingNotesApp.Models;
using AmazingNotesApp.Service;
using AmazingNotesApp.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmazingNotesApp
{
    public partial class App : Application
    {
        public static ItemService Service = new ItemService(new ItemRepository(new AmazingNotesContext()));
        public static ObservableCollection<Item> Items;

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
