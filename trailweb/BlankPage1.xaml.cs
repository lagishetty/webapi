using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 

        private dynamic books;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var str = e.Parameter as object;
            lv1.Items.Add(str);

            books = e.Parameter;

        }


        private async  void download_btn_Click(object sender, RoutedEventArgs e)
        {
            var id = books.ID;

            var uri = "http://it-ebooks-api.info/v1/book/" + id;
            await Launcher.LaunchUriAsync(new Uri(uri));


        //    string downloadurl = string.Empty;
        //    using (HttpClient client = new HttpClient())
        //    {
                
        //        string result = await GetResult("http://it-ebooks-api.info/v1/book/{book_id}");
        //        ListData bookDetails = JsonConvert.DeserializeObject<ListData>(result);
        //        if (bookDetails != null)
        //            downloadurl = bookDetails.Download;
        //    }
        //    await Launcher.LaunchUriAsync(new Uri(downloadurl));
        }
        //private async Task<string> GetResult(string url)
        //{
        //    string response1 = string.Empty;
        //    using (HttpClient client = new HttpClient())
        //    {

        //        var uri = "http://it-ebooks-api.info/v1/search/{0}";

        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = await client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            response1 = await response.Content.ReadAsStringAsync();                    
        //            var listdata = JsonConvert.DeserializeObject<RootObject>(response1);

        //        }
                 
        //    }
        //    return response1;
        //}
    }
}

  