using BloggingApp.Model;

namespace BloggingApp.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(string userId);
        Task<User> GetUserByUsername(string username);
        Task<IEnumerable<User>> GetAllUsers();
        Task RegisterUser(User user, string password);
        Task<User> Authenticate(string username, string password);
        Task AddToRole(User user, string roleName);
        Task<bool> IsInRole(User user, string roleName);

    }
}
