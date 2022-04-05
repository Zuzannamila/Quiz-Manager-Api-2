using quiz_manager.Models;

namespace quiz_manager.Services.Interfaces
{
    public interface IQuestionDataRepository
    {
        Task<Question> AddQuestion(Question question);
        IEnumerable<Question> GetQuestionsForQuizId(string Id);
    }
}
