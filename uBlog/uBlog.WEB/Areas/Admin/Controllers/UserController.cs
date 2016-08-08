using System.Web.Mvc;
using uBlog.BLL.Interfaces;

namespace uBlog.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        readonly IBlogService _blogService;
        public UserController(IBlogService serv)
        {
            _blogService = serv;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}