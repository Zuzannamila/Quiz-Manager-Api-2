using quiz_manager.Models;

namespace quiz_manager.Services.Interfaces
{
    public interface IQuizDataRepository
    {
        Task<Quiz> AddQuiz(Quiz quiz);
    }
}
