using Blog.Security.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Blog.Security.Infrastructure.DBContext
{
    public class BlogIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public BlogIdentityDbContext(DbContextOptions<BlogIdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<BlogUser>(s =>
            {
                s.ToTable("BlogUser").Property(p => p.Id).HasColumnName("UserId");
            });
            modelBuilder.Entity<IdentityRole>().ToTable("BlogRole");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("BlogUserRole");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("BlogUserClaim");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("BlogUserLogin");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("BlogRoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("BlogUserTokens");
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER" });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // ...
        }
    }
}
