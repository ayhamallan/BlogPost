using Blog.DataModel.DataModels;
using Blog.DomainModel.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DomainModel.IServices
{
    public interface IBlogPostServie
    {
        PagedResults<BlogPost> GetPaged(int pageNo, int rowNum);
        void Update(int Id, BlogPost blogPost);
        void Delete(int Id);
    }
}
