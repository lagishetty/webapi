using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trailweb
{
    public class ListData
    {
        public string Error { get; set; }
        public double Time { get; set; }
        public long ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Year { get; set; }
        public string Page { get; set; }
        public string Publisher { get; set; }
        public string Image { get; set; }
        public string Download { get; set; }

    }

    public class RootObject1
    {
        
        public List<ListData> ff  { get; set; }

    }
   
}
