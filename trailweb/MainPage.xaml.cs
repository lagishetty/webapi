using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace trailweb
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void  search_btn_Click(object sender, RoutedEventArgs e)
        {
           

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    pgbar.Visibility = Visibility.Visible;

                    var uri = "http://it-ebooks-api.info/v1/search/{0}";

                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(String.Format(uri, tb1.Text));
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync();
                        var listdata = JsonConvert.DeserializeObject<RootObject>(data.Result);
                       
                        if (listdata != null && listdata.Books != null && listdata.Books.Count > 0)
                        lv1.ItemsSource = listdata.Books;
                       

                    }
                    else
                    {
                                   
                        var msg = new MessageDialog("Error").ShowAsync();

            
                    }
                    pgbar.Visibility = Visibility.Collapsed;

                }
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error" + ex).ShowAsync();
                pgbar.Visibility = Visibility.Collapsed;
            }
        }

       
        private void lv1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            lv1.SelectedItem = sender;
            this.Frame.Navigate(typeof(BlankPage1),lv1.SelectedItem);
        }
    }
}
