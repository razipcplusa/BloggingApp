using BloggingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BloggingApp.Repository
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository(BlogContext context) : base(context)
        {
        }

    }
}
