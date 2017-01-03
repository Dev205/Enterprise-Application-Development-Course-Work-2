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
    }
}