using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace trailweb
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var dbpath = ApplicationData.Current.LocalFolder.Path + "/ebook.db";
            var con = new SQLiteAsyncConnection(dbpath);
            await con.CreateTableAsync<Register>();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var dbpath = ApplicationData.Current.LocalFolder.Path + "/ebook.db";
            var con = new SQLiteAsyncConnection(dbpath);
            await con.CreateTableAsync<Register>();
            Register m = new Register();

            m.Name = text_reg.Text;
            m.Password = text_password.Password;
            string rd = "";
            if (radio_male.IsChecked == true)
            {
                rd = "Male";

            }
            else
            {
                rd = "Female";

            }
            m.Gender = rd;
            m.State = ((ComboBoxItem)combo_box.SelectedItem).Content.ToString();


            await con.InsertAsync(m);

            MessageDialog md = new MessageDialog("success");
            await md.ShowAsync();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer data = Windows.Storage.ApplicationData.Current.LocalSettings;
            data.Values["check"] = text_reg.Text;
            var dbpath = ApplicationData.Current.LocalFolder.Path + "/ebook.db";
            var con = new SQLiteAsyncConnection(dbpath);

            Register t = new Register();
            string query = string.Format("select Name,Password from Register where Name='{0}' and Password='{1}'", text_user.Text, text_pass.Password);
            List<Register> mylist = await con.QueryAsync<Register>(query);
            if (mylist.Count == 1)
            {
                t = mylist[0];
            }

            if (t.Name == text_user.Text && t.Password == text_pass.Password)
            {

                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                var messagedialog = new MessageDialog("Unsuccessful").ShowAsync();
            }
        }
    }
}
