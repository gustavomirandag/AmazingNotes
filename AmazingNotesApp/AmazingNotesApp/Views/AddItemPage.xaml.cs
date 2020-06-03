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
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
            SwitchReminder.Toggled += EnableDisableReminder;
        }

        private void EnableDisableReminder(object sender, EventArgs e)
        {
            DatePickerReminder.IsEnabled = SwitchReminder.IsToggled;
            TimePickerReminder.IsEnabled = SwitchReminder.IsToggled;
        }

        private void ButtonAddItem_Clicked(object sender, EventArgs e)
        {

            //Create Item
            var item = new Item();
            item.Title = EntryTitle.Text;
            item.Description = EntryDescription.Text;
            App.Items.Add(item);
            App.Service.CreateItem(item);

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

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}