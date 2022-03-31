using Microsoft.EntityFrameworkCore;
using quiz_manager.Models;
using quiz_manager.Services.Interfaces;

namespace quiz_manager.Services
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly zuzannadb1Context _dbContext;
        public UserDataRepository(zuzannadb1Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> AddUser(User newUser)
        {
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return newUser;
        }
    }
}
