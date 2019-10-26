using Blog.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataModel.DbContextFactory
{
    public class BlogPostDbContextFactory : DesignTimeDbContextFactoryBase<BlogDbContext>
    {
        protected override BlogDbContext CreateNewInstance(DbContextOptions<BlogDbContext> options)
        {
            return new BlogDbContext(options);
        }
    }
}
