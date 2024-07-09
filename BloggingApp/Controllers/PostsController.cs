using BloggingApp.Interfaces;
using BloggingApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloggingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public PostsController(IPostService postService, UserManager<User> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        // GET: api/posts
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        // POST: api/posts
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "Unauthorized: User is not logged in. Please log in to access this resource." });
            }
            // Set author from current user
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized(new { message = "Unauthorized: User not found." });
            }
            if (currentUser.Role != "Admin") // Check if the user is in the "admin" role
            {
                return Unauthorized(new { message = "Forbidden: You do not have permission to Add the post." });
            }
            //post.Author = currentUser.UserName;

            await _postService.AddPost(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.PostId }, post);
        }

        // PUT: api/posts/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdatePost(int id, Post post)
        {
            var existingPost = await _postService.GetPostById(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            // Check if user is authenticated
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "Unauthorized: User is not logged in. Please log in to access this resource." });
            }

            // Check if user is authorized to edit this post (Admin or Author)
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized(new { message = "Unauthorized: User not found." });
            }
            if (currentUser.Role != "Admin") // Check if the user is in the "admin" role
            {
                return Unauthorized(new { message = "Forbidden: You do not have permission to edit this post." });
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.Author = post.Author;
            existingPost.CreatedDate = post.CreatedDate;

            await _postService.UpdatePost(existingPost);
            return Ok(new { message="Post Updated Successfully!"});
        }

        // DELETE: api/posts/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var existingPost = await _postService.GetPostById(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            await _postService.DeletePost(id);
            return Ok(new { message = "Post Deleted Successfully!" });
        }

    }
}
