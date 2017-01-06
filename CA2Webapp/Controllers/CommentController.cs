using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace CA2Webapp.Controllers
{
    public class CommentController : Controller
    {

        DALAccess dataAccess;
        public CommentController()
        {
            dataAccess = new DALAccess();
            //init a comment here maybe

        }

        // GET: Comment
        public ActionResult newComment(long forumID, long postID)
        {
            TempData["postID"] = postID;
            TempData["routeForumID"] = forumID;
            return View();
        }

        [HttpPost]
        public ActionResult newComment(Comment comment)
        {
            long postID = (long)TempData["postID"];
            long forumID = (long)TempData["routeForumID"];
            if (ModelState.IsValid)
            {
                dataAccess.addComment(comment, postID);
                return RedirectToAction("Index", "Post", new { forumID = forumID, postID = postID });

            }

            return RedirectToAction("Index", "Post", new { forumID = forumID, postID = postID });
        }

        public ActionResult deleteComment(long commentID, long forumID, long postID)
        {
            dataAccess.removeItem(commentID, "comment");
            return RedirectToAction("Index", "Post", new { forumID = forumID, postID = postID });
        }


    }
}