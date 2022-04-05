using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiz_manager.Models;
using quiz_manager.Services.Interfaces;
using quiz_manager.ViewModels;

namespace quiz_manager.Controllers
{

    /// <summary>
    /// Controller responsible for quizzes
    /// </summary>
    [Route("api/quizzes")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizDataRepository _quizDataRepository;
        public QuizzesController(IQuizDataRepository quizDataRepository)
        {
            _quizDataRepository = quizDataRepository;
        }
        /// <summary>
        /// Endpoint responsible for creating quiz
        /// </summary>
        /// <remarks>
        ///
        /// Secured by jwt token (Authorization header)
        /// 
        /// Sample request:
        ///
        ///     POST /api/quizzes
        /// 
        /// </remarks>
        /// <param name="quiz">Quiz</param>
        /// <response code="201">Created quiz</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddQuiz(AddQuizViewModel quiz)
        {
            if (quiz.Title == null || quiz.Category == null || quiz.Description == null) return BadRequest();

            Guid quizId = Guid.NewGuid();
            Quiz newQuiz = new Quiz
            {
                Id = quizId,
                Title = quiz.Title,
                Description = quiz.Description,
                Category = quiz.Category,
                TotalCount = 0
            };
            Quiz addedQuiz;


            addedQuiz = await _quizDataRepository.AddQuiz(newQuiz);
            if (addedQuiz == null) return BadRequest();
            return Ok(newQuiz);
        }

        /// <summary>
        /// Endpoint responsible for getting quizzes
        /// <remarks>
        ///
        /// Secured by jwt token (Authorization header)
        /// 
        /// Sample request:
        ///
        ///     POST /api/quizzes
        /// 
        /// </remarks>
        /// <param name="id">Quiz</param>
        /// <response code="201">Found quiz</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public IActionResult GetQuizzes()
        {
            IEnumerable<Quiz> quizzes = new List<Quiz>();
            quizzes = _quizDataRepository.GetQuizzes();

            return Ok(quizzes.OrderBy(i => i.Title));
        }

        /// <summary>
        /// Endpoint responsible for getting quiz by Id
        /// <remarks>
        ///
        /// Secured by jwt token (Authorization header)
        /// 
        /// Sample request:
        ///
        ///     POST /api/quizzes
        /// 
        /// </remarks>
        /// <param name="id">Quiz</param>
        /// <response code="201">Found quiz</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            Quiz quiz;
            quiz = _quizDataRepository.GetById(id);
            if (quiz != null)
            {
                return Ok(quiz);
            }

            return NotFound();
        }
    }
}
