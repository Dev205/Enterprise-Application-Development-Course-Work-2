using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace CA2Webapp.Controllers
{
    public class ForumController : Controller
    {
        DALAccess dataAccess;

        public ForumController()
        {
            dataAccess = new DALAccess();
            //init forum
            if(dataAccess.GetNumberOfTable("forum") <= 0)
            {
                dataAccess.initForum();
            }
        }

        // GET: Forum
        public ActionResult Index()
        {
            var ForumModelView = dataAccess.getForums();
            return View(ForumModelView);
        }
        //get view
        public ActionResult addPostToForum(long forumID)
        {
            TempData["ForumID"] = forumID;
            return View();
        }
        //post 
        [HttpPost]
        public ActionResult addPostToForum(Post post)
        {
            if (ModelState.IsValid)
            {
                long forumID = (long)TempData["ForumID"];
                dataAccess.addForumPost(post, forumID);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        //get new forum view
        public ActionResult addNewForum()
        {
            return View();
        }
        //post for adding a new forum
        [HttpPost]
        public ActionResult addNewForum(Forum newForum)
        {
            if (ModelState.IsValid)
            {
                dataAccess.addNewForum(newForum);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}