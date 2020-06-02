using AmazingNotesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmazingNotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListItemsPage : ContentPage
    {
        public ListItemsPage()
        {
            InitializeComponent();
            ListViewItems.ItemsSource = App.Items;
            ListViewItems.ItemTapped += DeleteItem;
        }

        private void DeleteItem(object sender, ItemTappedEventArgs e)
        {
            App.Items.Remove((Item)e.Item);
        }
        

        private void ButtonAddItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddItemPage(),true);
        }
    }
}