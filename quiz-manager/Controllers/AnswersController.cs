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
    [Route("api/")]
    [ApiController]
    public class AnswersController : Controller
    {
        private readonly IAnswerDataRepository _answerDataRepository;
        public AnswersController(IAnswerDataRepository answerDataRepository)
        {
            _answerDataRepository = answerDataRepository;
        }

        /// <summary>
        /// Endpoint responsible for creating answers
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
        /// <param name="id">Question id</param>
        /// <param name="answers">Answers</param>
        /// <response code="201">Created answers</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("{id}/answers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAnswers(IEnumerable<AddAnswerViewModel> answers, string id)
        {
            foreach(AddAnswerViewModel answer in answers)
            {
                if (answer.Content == null) return BadRequest();
            }
            List<Answer> newAnswers = new List<Answer>();
            Guid questionGuid = Guid.Parse(id);
            foreach (AddAnswerViewModel answer in answers)
            {
                Guid answerGuid = Guid.NewGuid();
                Answer newAnswer = new Answer
                {
                    Id = answerGuid,
                    QuestionId = questionGuid,
                    Content = answer.Content,
                    IsCorrect = answer.IsCorrect
                };
                newAnswers.Add(newAnswer);
            }       
            IEnumerable<Answer> addedAnswers;

            addedAnswers = await _answerDataRepository.AddAnswers(newAnswers);
            return Ok(addedAnswers);
        }
    }
}
