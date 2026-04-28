using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sem2FirstProject.Data.Entities;

namespace Sem2FirstProject.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
                
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<ModuleInstructor> ModuleInstructors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole<Guid>>().ToTable("Roles");

            SeedRoles(builder);
        }

        public void SeedRoles(ModelBuilder builder)
        {
            List<IdentityRole<Guid>> identityRoles = [
                new IdentityRole<Guid>{
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole<Guid>{
                    Id = Guid.NewGuid(),
                    Name = "Student",
                    NormalizedName = "STUDENT",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole<Guid>{
                    Id = Guid.NewGuid(),
                    Name = "Instructor",
                    NormalizedName = "INSTRUCTOR",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                }
                ];

            builder.Entity<IdentityRole<Guid>>().HasData(identityRoles);
        }

    }
}
