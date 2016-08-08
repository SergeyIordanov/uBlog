using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.WEB.ViewModels;

namespace uBlog.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReviewController : Controller
    {
        readonly IBlogService _blogService;
        public ReviewController(IBlogService serv)
        {
            _blogService = serv;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReviewDto, ReviewViewModel>();
            });
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ReviewViewModel>>(_blogService.GetReviewes()));
        }

        [HttpPost]
        public ActionResult DeleteReview(int? id)
        {
            try
            {
                _blogService.DeleteReview(id);
            }
            catch (ValidationException) { }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDto, ReviewViewModel>());
            var mapper = config.CreateMapper();
            return PartialView("Partials/_ReviewList", mapper.Map<IEnumerable<ReviewViewModel>>(_blogService.GetReviewes()));
        }
    }
}