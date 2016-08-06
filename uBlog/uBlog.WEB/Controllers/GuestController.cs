using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.WEB.ViewModels;

namespace uBlog.WEB.Controllers
{
    public class GuestController : Controller
    {
        readonly IBlogService _blogService;
        public GuestController(IBlogService serv)
        {
            _blogService = serv;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDto, ReviewViewModel>());
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ReviewViewModel>>(_blogService.GetReviewes()));
        }

        [HttpPost]
        public ActionResult Index(ReviewViewModel review)
        {
            var configView = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDto, ReviewViewModel>());
            var configDto = new MapperConfiguration(cfg => cfg.CreateMap<ReviewViewModel, ReviewDto>());
            var mapper = configDto.CreateMapper();

            try
            {
                review.PublishDate = DateTime.UtcNow;               
                var reviewDto = mapper.Map<ReviewDto>(review);
                _blogService.CreateReview(reviewDto);               
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            mapper = configView.CreateMapper();
            var model = mapper.Map<IEnumerable<ReviewViewModel>>(_blogService.GetReviewes());
            return PartialView("Partials/_ReviewList", model);
        }       
    }
}