using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.WEB.ViewModels;

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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDto, ArticleViewModel>();
            });
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleViewModel>>(_blogService.GetArticles()));
        }

        [HttpGet]
        public ActionResult ShowArticle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            try
            {
                var article = _blogService.GetArticle(id);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ArticleDto, ArticleViewModel>();
                });
                var mapper = config.CreateMapper();
                return View(mapper.Map<ArticleViewModel>(article));
            }
            catch (ValidationException ex)
            {
                return View("Error", ex);
            }
            
        }

        [HttpGet]
        public ActionResult SearchByTag(string tag)
        {
            if (tag == null)
            {
                tag = "";
            }
            try
            {
                var articles = _blogService.GetArticles(tag);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ArticleDto, ArticleViewModel>();
                });
                var mapper = config.CreateMapper();
                var articlesView = mapper.Map<IEnumerable<ArticleViewModel>>(articles);
                return View(new SearchByTagViewModel { Articles = articlesView.ToList(), TagText = tag });
            }
            catch (ValidationException ex)
            {
                return View("Error", ex);
            }

        }       
    }
}