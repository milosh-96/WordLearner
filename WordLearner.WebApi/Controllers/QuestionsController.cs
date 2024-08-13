using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordLearner.Domain.Services;
using WordLearner.Domain.WordAggregate;
using WordLearner.Infrastructure.Services;

namespace WordLearner.WebApi.Controllers
{
    [Route("api/[controller]/{action=Index}")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IWordService _wordService;
        public QuestionsController(IQuestionService questionService, IWordService wordService)
        {
            _questionService = questionService;
            _wordService = wordService;
        }

        public IActionResult Index()
        {
            return new JsonResult(new { Message = "Hello" });
        }
        [HttpGet]
        public IActionResult Generate(string languageCode = "de")
        {
            Translation word = _wordService.GetRandomWord(languageCode);
            var choices = _wordService.GetWords().OrderBy(r => Guid.NewGuid()).Take(3).Select(x => x.Content).ToList();

            return new JsonResult(
                _questionService.GenerateQuestion(word.Content, word.TargetWord.Content,choices)
                );
        }
    }
}
