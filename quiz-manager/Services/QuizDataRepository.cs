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

        public Quiz SaveQuiz(Quiz updatedQuiz)
        {
            Quiz result;
            result = _dbContext.Quizzes.FirstOrDefault(i => i.Id == updatedQuiz.Id);
            result.Title = updatedQuiz.Title;
            result.Description= updatedQuiz.Description;
            result.Category = updatedQuiz.Category;
            _dbContext.SaveChanges();
            return updatedQuiz;
        }

        public Quiz GetById(string id)
        {
            return _dbContext.Quizzes.FirstOrDefault(q => q.Id.ToString() == id);
        }

        public IEnumerable<Quiz> GetQuizzes()
        {
            return _dbContext.Quizzes;
        }
    }
}
