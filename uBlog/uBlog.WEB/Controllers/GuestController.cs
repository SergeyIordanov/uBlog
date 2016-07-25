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
    public class GuestController : Controller
    {
        IBlogService blogService;
        public GuestController(IBlogService serv)
        {
            blogService = serv;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, ReviewViewModel>());
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ReviewViewModel>>(blogService.GetReviewes()));
        }

        [HttpPost]
        public ActionResult Index(ReviewViewModel review)
        {
            IEnumerable<ReviewViewModel> model;
            var configView = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, ReviewViewModel>());
            var configDTO = new MapperConfiguration(cfg => cfg.CreateMap<ReviewViewModel, ReviewDTO>());
            var mapper = configDTO.CreateMapper();

            try
            {
                review.PublishDate = DateTime.UtcNow;               
                var reviewDTO = mapper.Map<ReviewDTO>(review);
                blogService.CreateReview(reviewDTO);               
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            mapper = configView.CreateMapper();
            model = mapper.Map<IEnumerable<ReviewViewModel>>(blogService.GetReviewes());
            return PartialView("Partials/_ReviewList", model);
        }
    }
}