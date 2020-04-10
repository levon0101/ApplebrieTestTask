using ApplebrieTestTask.WebApi.Entitities;
using Microsoft.EntityFrameworkCore;

namespace ApplebrieTestTask.WebApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Programmers" },
                new Category { Id = 2, Name = "TeamLiders" },
                new Category { Id = 3, Name = "Designers" },
                new Category { Id = 4, Name = "HRs" }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Levon",
                    LastName = "Mardanyan",
                    CategoryId = 1
                },
                new User
                {
                    Id = 2,
                    FirstName = "Smbat",
                    LastName = "Jamalyan",
                    CategoryId = 1
                },
                new User
                {
                    Id = 3,
                    FirstName = "Tigran",
                    LastName = "Mnatsakanyan",
                    CategoryId = 2
                },
                new User
                {
                    Id = 4,
                    FirstName = "Other",
                    LastName = "Lead",
                    CategoryId = 2
                },
                new User
                {
                    Id = 5,
                    FirstName = "Kristina",
                    LastName = "Khachatryan",
                    CategoryId = 4
                }
            );

          

            base.OnModelCreating(modelBuilder);
        }
    }
}
