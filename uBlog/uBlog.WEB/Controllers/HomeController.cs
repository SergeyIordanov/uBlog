﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.WEB.Models;
using static System.String;

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
                    var tags = article.Tags.FirstOrDefault().Split(' ');
                    article.Tags.Clear();
                    foreach (var tag in tags)
                    {
                        if(tag.Trim() == Empty) continue;
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

        [HttpPost]
        public ActionResult Delete(int? id)
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