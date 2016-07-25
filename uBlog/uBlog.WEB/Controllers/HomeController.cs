using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.WEB.Models;

namespace uBlog.WEB.Controllers
{
    public class HomeController : Controller
    {
        
        IBlogService blogService;
        public HomeController(IBlogService serv)
        {
            blogService = serv;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>());
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleViewModel>>(blogService.GetArticles()));
        }

        [HttpPost]
        public ActionResult Index(ArticleViewModel article)
        {
            IEnumerable<ArticleViewModel> model;
            var configView = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>());
            var configDTO = new MapperConfiguration(cfg => cfg.CreateMap<ArticleViewModel, ArticleDTO>());
            var mapper = configDTO.CreateMapper();

            try
            {
                article.PublishDate = DateTime.UtcNow;
                var articleDTO = mapper.Map<ArticleDTO>(article);
                blogService.CreateArticle(articleDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            mapper = configView.CreateMapper();
            model = mapper.Map<IEnumerable<ArticleViewModel>>(blogService.GetArticles());
            return PartialView("Partials/_ArticleList", model);
        }
    }
}