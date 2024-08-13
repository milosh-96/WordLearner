using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordLearner.Domain.Services;
using WordLearner.Domain.WordAggregate;

namespace WordLearner.WebApi.Controllers
{
    [Route("api/[controller]/{action=Index}")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordService _wordService;

        public WordsController(IWordService wordService)
        {
            _wordService = wordService;
        }

        public IActionResult Index()
        {
            return new JsonResult(_wordService.GetWords());
        }

        public IActionResult GetRandomWord(string languageCode = "de")
        {
            return new JsonResult(_wordService.GetRandomWord(languageCode));
        }
    }
}
