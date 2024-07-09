using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloggingApp.Model
{
    public class BlogContext : IdentityDbContext<User>
    {

        public BlogContext(DbContextOptions<BlogContext> options): base(options) 
        {
            
        }

        public DbSet<Post> posts { get; set; } 
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configurations if needed
        }
    }

    }
