using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Post
    {
        //could add a datetime and user
        //this is where the discussion of the post will be
        public long ID { get; set; }

        [Display(Name ="Post Title")]
        [Required(ErrorMessage ="A post needs a title!")]
        public string Title { get; set; }

        public Forum Forum { get; set; }

        //collection of the comments on the post
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
