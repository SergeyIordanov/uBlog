using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.WEB.ViewModels;

namespace uBlog.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ArticleController : Controller
    {
        readonly IBlogService _blogService;
        public ArticleController(IBlogService serv)
        {
            _blogService = serv;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDto, ArticleViewModel>();
            });
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleViewModel>>(_blogService.GetArticles()));
        }

        [HttpPost]
        public ActionResult Index(ArticleViewModel article)
        {
            var configView = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDto, ArticleViewModel>();
            });
            var configDto = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleViewModel, ArticleDto>();
            });
            var mapper = configDto.CreateMapper();

            try
            {
                article.PublishDate = DateTime.UtcNow;
                if (article.Tags != null && article.Tags.Count > 0)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    var tags = article.Tags.FirstOrDefault().Split(' ');
                    article.Tags.Clear();
                    foreach (var tag in tags)
                    {
                        if (tag.Trim() == string.Empty) continue;
                        article.Tags.Add(tag.Trim());
                    }
                }
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
        public ActionResult DeleteArticle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            try
            {
                _blogService.DeleteArticle(id);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ArticleDto, ArticleViewModel>();
                });
                var mapper = config.CreateMapper();
                return PartialView("Partials/_ArticleList",
                    mapper.Map<IEnumerable<ArticleViewModel>>(_blogService.GetArticles()));
            }
            catch (ValidationException ex)
            {
                return PartialView("_ErrorPartial", ex);
            }
        }
    }
}