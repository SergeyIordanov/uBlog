using EPAM_MVC_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPAM_MVC_2.Controllers
{
    public class HomeController : Controller
    {

        #region Index (Main)
        [HttpGet]
        public ActionResult Index()
        {
            generateFakeArticles();
            if (Session["Articles"] != null)
            {
                return View(Session["Articles"]);
            }
            return View(new List<Article>());
        }

        private void generateFakeArticles()
        {
            List<Article> articles = new List<Article>();           
            articles.Add(new Article() {
                Title = "The First Article",
                Text = "Dear Readers,\r\nWe are glad to see you in our minimalistic blog calling 'uBlog'!\r\n" +
                    "It's the first step in our long fantastic journey. Hope you'll stay with us!\r\n\r\nGood luck!",
                PublishDate = DateTime.Today
            });
            articles.Add(new Article() {
                Title = "Hot News!",
                Text = "Hello, everybody!\r\nI just need to say you that I'am the only one person who reads this articles.. and writes it.\r\n" +
                "Maybe I should rename this blog for 'uDiary'? Or it's just a schizophrenia?\r\n\r\nAnyway, stay awesome, bros!",
                PublishDate = DateTime.Today
            });
            articles.Add(new Article()
            {
                Title = "Very Interesting Article",
                Text = "Hi, guys!\r\nThis article was writen just for testing 'uBlog'. There is no usefull information for you, " +
                    "but we need at least three articles to be sure that our blog is exactly the same like we saw it!\r\n\r\nStay awesome, bros!",
                PublishDate = DateTime.Today
            });
            Session["Articles"] = articles;
        }
        #endregion

        #region Guest (Reviewes)
        [HttpGet]
        public ActionResult Guest()
        {
            if (Session["Reviewes"] != null)
            {
                return View(Session["Reviewes"]);
            }
            return View(new List<Review>());
        }

        [HttpPost]
        public ActionResult Guest(Review review)
        {
            if (Session["Reviewes"] == null)
            {
                Session["Reviewes"] = new List<Review>();
            }
            if (review != null)
            {
                List<Review> temp = (List<Review>)Session["Reviewes"];
                review.PublishDate = DateTime.Now;
                temp.Add(review);
                Session["Reviewes"] = temp;                  
            }
            return PartialView("Partials/_ReviewList", Session["Reviewes"]);
        }
        #endregion

        #region Quize & QuizeResult
        [HttpGet]
        public ActionResult Quize()
        {
            return View();
        }

        public ActionResult QuizeResult(UserInfo userInfo)
        {
            return View(userInfo);
        }
        #endregion
    }
}