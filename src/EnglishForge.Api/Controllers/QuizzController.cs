using EnglishForge.Domain.Abstractions.Application;
using EnglishForge.Domain.Enumerators;
using Microsoft.AspNetCore.Mvc;

namespace EnglishForge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzController : ControllerBase
    {
        private readonly IQuizzAppService _quizzAppService;

        public QuizzController(IQuizzAppService quizzAppService)
        {
            _quizzAppService = quizzAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizz([FromQuery] QuestionTypes type, [FromQuery] int size, CancellationToken cancellationToken = default)
        {
            var result = await _quizzAppService.GetQuizzAsync(type, size, cancellationToken);
            return Ok(result);
        }
    }
}
