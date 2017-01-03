using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace CA2Webapp.Controllers
{
    public class ArticleController : Controller
    {
        DALAccess DAL;

        public ArticleController()
        {
            DAL = new DALAccess();
            //init article 
            if (DAL.GetNumberOfTable("article") <= 0)
            {
                DAL.InitArticle();
            }
        }

        // GET: Article
        public ActionResult Index()
        {
            //can use this to select the article that is to be displayed on the main page, the default will be the latest, and the id
            //will be used to get previous articles
            var mainArticle = DAL.GetArticle(1);
            return View(mainArticle);
        }
    }
}