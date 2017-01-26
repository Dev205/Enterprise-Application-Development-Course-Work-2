using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Comment
    {
        //could add a datetime and user
        public long ID { get; set; }
        public string Content { get; set; }

        
        public Post Post { get; set; }


    }
}
