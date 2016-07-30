using System.Linq;
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
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<QuestionDto, QuestionViewModel>();
                cfg.CreateMap<AnswerDto, AnswerViewModel>();
            });
            var mapper = config.CreateMapper();
            var questionView = mapper.Map<QuestionDto, QuestionViewModel>(_blogService.GetQuestion(id));
            return PartialView("_Poll", questionView);
        }

        [HttpPost]
        public ActionResult Index(int questionId, int answerId)
        {
            var questionDto = _blogService.GetQuestion(questionId);

            var answerDto = questionDto.Answers.First(x => x.AnswerId == answerId);
            answerDto.VotesCount ++;
            _blogService.UpdateAnswer(answerDto);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<QuestionDto, QuestionViewModel>();
                cfg.CreateMap<AnswerDto, AnswerViewModel>();
            });
            var mapper = config.CreateMapper();
            var pollResult = new PollResultViewModel
            {
                Question = mapper.Map<QuestionDto, QuestionViewModel>(questionDto),
                AnswerId = answerId
            };

            return PartialView("_PollResult", pollResult);
        }
    }
}