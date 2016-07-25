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
        readonly IBlogService _blogService;
        public HomeController(IBlogService serv)
        {
            _blogService = serv;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDto, ArticleViewModel>());
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleViewModel>>(_blogService.GetArticles()));
        }

        [HttpPost]
        public ActionResult Index(ArticleViewModel article)
        {
            var configView = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDto, ArticleViewModel>());
            var configDto = new MapperConfiguration(cfg => cfg.CreateMap<ArticleViewModel, ArticleDto>());
            var mapper = configDto.CreateMapper();

            try
            {
                article.PublishDate = DateTime.UtcNow;
                var articleDto = mapper.Map<ArticleDto>(article);
                _blogService.CreateArticle(articleDto);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            mapper = configView.CreateMapper();
            var model = mapper.Map<IEnumerable<ArticleViewModel>>(_blogService.GetArticles());
            return PartialView("Partials/_ArticleList", model);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {
                _blogService.DeleteArticle(id);
            }
            catch (ValidationException){ }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDto, ArticleViewModel>());
            var mapper = config.CreateMapper();
            return PartialView("Partials/_ArticleList", mapper.Map<IEnumerable<ArticleViewModel>>(_blogService.GetArticles()));
        }

    }
}