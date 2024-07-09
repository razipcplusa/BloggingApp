using BloggingApp.Interfaces;
using BloggingApp.Model;

namespace BloggingApp.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;

        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _postRepository.GetAll();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _postRepository.GetById(id);
        }

        public async Task AddPost(Post post)
        {
            await _postRepository.Add(post);
        }

        public async Task UpdatePost(Post post)
        {
            await _postRepository.Update(post);
        }

        public async Task DeletePost(int id)
        {
            await _postRepository.Delete(id);
        }
    }
}
