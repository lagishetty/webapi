using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trailweb
{
        public class Book1
        {
            public object ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public string isbn { get; set; }
            public string SubTitle { get; set; }
           
        }


        public class RootObject
        {
            public string Error { get; set; }
            public double Time { get; set; }
            public string Total { get; set; }
            public int Page { get; set; }
            public List<Book1> Books { get; set; }

        }
    
}
