using Coffee.Model;
using Coffee.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News => Set<News>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<User>()
                .Property(x => x.Created)
                .HasDefaultValueSql("now()");

            builder
                .Entity<News>()
                .Property(x => x.Date)
                .HasDefaultValueSql("now()");

            builder
                .Entity<News>()
                .Property(x => x.CreateDate)
                .HasDefaultValueSql("now()");
            builder
                .Entity<News>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
        }
    }
}