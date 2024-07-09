using BloggingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BloggingApp.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(BlogContext context) : base(context)
        {
        }

    }
}
