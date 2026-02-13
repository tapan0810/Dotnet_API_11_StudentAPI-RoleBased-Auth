using Dotnet_API_11_.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_11_.Data
{
    public class StudentAuthDbContext:DbContext
    {
        public StudentAuthDbContext(DbContextOptions<StudentAuthDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Student> Students =>Set<Student>();
    }
}
