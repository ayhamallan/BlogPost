using System;
using Microsoft.EntityFrameworkCore;
namespace Blog.Security.Infrastructure.DBContext
{
    public class BlogIdentityDbContextFactory : DesignTimeDbContextFactoryBase<BlogIdentityDbContext>
    {
        protected override BlogIdentityDbContext CreateNewInstance(DbContextOptions<BlogIdentityDbContext> options)
        {
            return new BlogIdentityDbContext(options);
        }
    }
}
