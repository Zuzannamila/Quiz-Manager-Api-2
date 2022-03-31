using quiz_manager.Models;


namespace quiz_manager.Services.Interfaces
{
    public interface IUserDataRepository
    {
        Task<List<User>> GetUsers();
        Task<User> AddUser(User user);
    }
}
