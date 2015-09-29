using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;
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
using Windows.Storage;
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var dbpath = ApplicationData.Current.LocalFolder.Path + "/ebook.db";
            var con = new SQLiteAsyncConnection(dbpath);

            await con.CreateTableAsync<DownloadList>();

            var str = e.Parameter as object;

            lv1.Items.Add(str); 

            books = e.Parameter; 

        }


        private async  void download_btn_Click(object sender, RoutedEventArgs e)
        {
            var dbpath = ApplicationData.Current.LocalFolder.Path + "/ebook.db";
            var con = new SQLiteAsyncConnection(dbpath);


            var id = books.ID;

            var uri = "http://it-ebooks-api.info/v1/book/" + id;
            HttpClient client = new HttpClient();
             client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync();
                        var listdata = JsonConvert.DeserializeObject<ListData>(data.Result);

                        var file_down = listdata.Download;
                        await Launcher.LaunchUriAsync(new Uri(file_down));
                    }
                    DownloadList dl = new DownloadList();
                    dl.Mylist = books.Title;
                    await con.InsertAsync(dl);

        }
        
    }
}

  