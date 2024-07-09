using BloggingApp.Model;

namespace BloggingApp.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task AddPost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(int id);

    }
}
