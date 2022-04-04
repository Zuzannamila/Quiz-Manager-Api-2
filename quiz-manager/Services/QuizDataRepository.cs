using quiz_manager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using quiz_manager.Models;

namespace quiz_manager.Services
{
    public class QuizDataRepository :IQuizDataRepository

    {
        private zuzannadb1Context _dbContext;
        public QuizDataRepository(zuzannadb1Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Quiz> AddQuiz(Quiz newQuiz)
        {
            _dbContext.Quizzes.Add(newQuiz);
            await _dbContext.SaveChangesAsync();
            return newQuiz;
        }
    }
}
