using AmazingNotesApp.Models;
using Plugin.LocalNotifications;
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
    public partial class UpdateItemPage : ContentPage
    {
        private Item item;

        public UpdateItemPage(Item item)
        {
            InitializeComponent();
            this.item = item;

            EntryTitle.Text = item.Title;
            EntryDescription.Text = item.Description;
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }

        private void ButtonUpdateItem_Clicked(object sender, EventArgs e)
        {
            //Update Item
            item.Title = EntryTitle.Text;
            item.Description = EntryDescription.Text;
            App.Service.UpdateItem(item);

            //LocalNotification
            if (SwitchReminder.IsToggled)
            {
                var reminderDateTime = new DateTime(
                    DatePickerReminder.Date.Year,
                    DatePickerReminder.Date.Month,
                    DatePickerReminder.Date.Day,
                    TimePickerReminder.Time.Hours,
                    TimePickerReminder.Time.Minutes,
                    0
                    );

                CrossLocalNotifications.Current.Show(
                    item.Title,
                    item.Description,
                    App.Items.Count - 1,
                    reminderDateTime
                    );
            }

            Navigation.PopModalAsync(true);
        }
    }
}