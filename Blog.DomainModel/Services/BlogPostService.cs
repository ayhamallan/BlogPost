using Blog.DataModel.DataModels;
using Blog.DomainModel.Helpers;
using Blog.DomainModel.IServices;
using Blog.Repository.GenericRepository;
using Blog.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.DomainModel.Services
{
    public class BlogPostService : IBlogPostServie
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<BlogPost> _repo;

        public BlogPostService(IUnitOfWork unit, IRepository<BlogPost> repo)
        {
            _uow = unit;
            _repo = repo;
        }
        public PagedResults<BlogPost> GetPaged(int pageNo , int rowNo)
        {
            int pageIndex = pageNo - 1;
            int skipedItem = pageIndex * rowNo;
            var blogPosts = _repo.Get().Skip(skipedItem).Take(rowNo).ToList();
            return new PagedResults<BlogPost>
            {
                Results = blogPosts,
                TotalRecords = blogPosts.Count
            };

        }
        public void Update(int Id, BlogPost blogPost)
        {
            var oldPost = _repo.Get(s => s.ID == Id).FirstOrDefault();
            oldPost.Auther = blogPost.Auther;
            oldPost.Body = blogPost.Body;
            oldPost.ImageUrl = blogPost.ImageUrl;
            oldPost.Subtitle = blogPost.Subtitle;
            oldPost.Title = blogPost.Title;
            _repo.Update(oldPost);
        }
        public void Delete(int Id)
        {
            var Post = _repo.Get(s => s.ID == Id).FirstOrDefault();
            _repo.Delete(Id);
        }
    }
}
