﻿using AmazingNotesApp.Models;
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
            App.Items = new ObservableCollection<Item>(App.Service.GetAll());
            ListViewItems.ItemsSource = App.Items;
            ListViewItems.IsPullToRefreshEnabled = true;
            ListViewItems.ItemTapped += UpdateItem;
        }

        private void UpdateItem(object sender, ItemTappedEventArgs e)
        {
            var item = (Item)e.Item;
            Navigation.PushModalAsync(new UpdateItemPage(item));
            ListViewItems.SelectedItem = null;
        }       

        private void ButtonAddItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddItemPage(),true);
        }

        private void ButtonRemove_Clicked(object sender, EventArgs e)
        {
            Guid itemId = (Guid)((Button)sender).CommandParameter;
            var item = App.Service.GetItemById(itemId);
            App.Items.Remove(item);
            App.Service.DeleteItem(item.Id);
        }
    }
}