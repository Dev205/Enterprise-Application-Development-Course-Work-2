using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Article
    {
        public long ID { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        //reference to the user that submitted the article
        public string UserName { get; set; }

    }
}
