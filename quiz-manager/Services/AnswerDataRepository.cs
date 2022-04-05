using quiz_manager.Models;
using quiz_manager.Services.Interfaces;

namespace quiz_manager.Services
{
    public class AnswerDataRepository : IAnswerDataRepository
    {
        private zuzannadb1Context _dbContext;
        public AnswerDataRepository(zuzannadb1Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Answer>> AddAnswers(List<Answer> newAnswers)
        {
            _dbContext.Answers.AddRange(newAnswers);
            await _dbContext.SaveChangesAsync();
            return newAnswers;
        }
    }
}
