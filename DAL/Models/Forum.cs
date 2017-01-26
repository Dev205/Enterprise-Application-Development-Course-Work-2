using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Forum
    {

        public long ID { get; set; }
        [Required]
        public string Title { get; set; }



        //has a collection of posts, with comments.
        public virtual ICollection<Post> Posts { get; set; }


    }
}
