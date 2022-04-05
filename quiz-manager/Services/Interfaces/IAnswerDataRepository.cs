using quiz_manager.Models;

namespace quiz_manager.Services.Interfaces
{
    public interface IAnswerDataRepository
    {
        Task<IEnumerable<Answer>> AddAnswers(List<Answer> answers);
        IEnumerable<Answer> GetAnswersForQuestionId(string Id);
    }
}
