using System.Web.Mvc;
using AutoMapper;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Interfaces;
using uBlog.WEB.Models;

namespace uBlog.WEB.Controllers
{
    public class PollController : Controller
    {
        readonly IBlogService _blogService;

        public PollController(IBlogService serv)
        {
            _blogService = serv;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<QuestionDto, QuestionViewModel>();
                cfg.CreateMap<AnswerDto, AnswerViewModel>();
            });
            var mapper = config.CreateMapper();
            var questionView = mapper.Map<QuestionDto, QuestionViewModel>(_blogService.GetQuestion(id));
            return PartialView("_Poll", questionView);
        }

        [HttpPost]
        public ActionResult Index(QuestionViewModel question)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<QuestionViewModel, QuestionDto>();
                cfg.CreateMap<AnswerViewModel, AnswerDto>();
            });
            var mapper = config.CreateMapper();
            var questionDto = mapper.Map<QuestionViewModel, QuestionDto>(question);

            foreach (AnswerDto answerDto in questionDto.Answers)
            {
                _blogService.UpdateAnswer(answerDto);
            }

            return RedirectToAction("Index", question.QuestionId);
        }
    }
}