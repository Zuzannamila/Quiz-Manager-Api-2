using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quiz_manager.Models;
using quiz_manager.Services.Interfaces;
using quiz_manager.ViewModels;

namespace quiz_manager.Controllers
{
    /// <summary>
    /// Controller responsible for quizzes
    /// </summary>
    [Route("api")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private readonly IQuestionDataRepository _questionDataRepository;
        public QuestionsController(IQuestionDataRepository questionDataRepository)
        {
            _questionDataRepository = questionDataRepository;
        }

        /// <summary>
        /// Endpoint responsible for creating question
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
        /// <param name="id">Quiz id</param>
        /// <param name="question">Question</param>
        /// <response code="201">Created question</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("{id}/questions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddQuestion(AddQuestionViewModel question, string id)
        {
            if (question.Content == null) return BadRequest();

            Guid questionId = Guid.NewGuid();
            Guid quizGuid = Guid.Parse(id);
            Question newQuestion = new Question
            {
                Id = questionId,
                QuizId = quizGuid,
                Content = question.Content
            };
            Question addedQuestion;

            addedQuestion = await _questionDataRepository.AddQuestion(newQuestion);
            if (addedQuestion == null) return BadRequest();
            return Ok(newQuestion);
        }

        /// <summary>
        /// Endpoint responsible for getting questions for quiz Id
        /// <remarks>
        ///
        /// Secured by jwt token (Authorization header)
        /// 
        /// Sample request:
        ///
        ///     POST /api/quizzes
        /// 
        /// </remarks>
        /// <param name="id">Quiz Id</param>
        /// <response code="200">Questions</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}/questions")]
        public IActionResult GetQuestionsForQuiz(string id)
        {
            IEnumerable<Question> questions;
            questions = _questionDataRepository.GetQuestionsForQuizId(id);
            return Ok(questions);
        }
    }
}
