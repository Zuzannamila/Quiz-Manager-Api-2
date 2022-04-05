using quiz_manager.Models;
using quiz_manager.Services.Interfaces;

namespace quiz_manager.Services
{
    public class QuestionDataRepository : IQuestionDataRepository
    {
        private zuzannadb1Context _dbContext;
        public QuestionDataRepository(zuzannadb1Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Question> AddQuestion(Question newQuestion)
        {
            _dbContext.Questions.Add(newQuestion);
            await _dbContext.SaveChangesAsync();
            return newQuestion;
        }

        public IEnumerable<Question> GetQuestionsForQuizId(string id)
        {
            return _dbContext.Questions.Where(q => q.QuizId.ToString() == id);
        }
    }
}
