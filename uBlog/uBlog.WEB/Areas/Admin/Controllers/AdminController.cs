using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web.Mvc;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Interfaces;
using uBlog.WEB.ViewModels;
using uBlog.BLL.Infrastructure;

namespace uBlog.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}