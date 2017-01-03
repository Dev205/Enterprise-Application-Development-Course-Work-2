using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace CA2Webapp.Controllers
{
    public class PostController : Controller
    {
        DALAccess dataAccess;

        public PostController()
        {
            dataAccess = new DALAccess();

        }
        // GET: Post
        public ActionResult Index(int forumID, int postID)
        {
            var postModelView = dataAccess.getPost(forumID, postID);
            return View(postModelView);
        }
    }
}