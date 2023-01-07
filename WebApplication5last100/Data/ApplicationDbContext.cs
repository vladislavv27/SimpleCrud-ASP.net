using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication5last100.Models;

namespace WebApplication5last100.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication5last100.Models.CourseName> CourseName { get; set; }
        public DbSet<WebApplication5last100.Models.Student> Student { get; set; }
    }
}