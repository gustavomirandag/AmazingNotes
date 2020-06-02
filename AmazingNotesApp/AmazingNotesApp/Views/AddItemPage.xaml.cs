using AmazingNotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmazingNotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
        }

        private void ButtonAddItem_Clicked(object sender, EventArgs e)
        {
            var item = new Item();
            item.Title = EntryTitle.Text;
            item.Description = EntryDescription.Text;
            App.Items.Add(item);

            Navigation.PopModalAsync(true);
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}