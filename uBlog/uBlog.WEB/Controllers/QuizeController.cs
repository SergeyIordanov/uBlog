using AutoMapper;
using System.Web.Mvc;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.WEB.Models;

namespace uBlog.WEB.Controllers
{
    public class QuizeController : Controller
    {
        IBlogService blogService;
        public QuizeController(IBlogService serv)
        {
            blogService = serv;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserInfoViewModel userInfo)
        {
            try
            {
                Mapper.Initialize(ctg => ctg.CreateMap<UserInfoViewModel, UserInfoDTO>());
                var userInfoDTO = Mapper.Map<UserInfoDTO>(userInfo);
                blogService.CreateUserInfo(userInfoDTO);
                return View("QuizeResult", userInfo);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(userInfo);
        }
    }
}