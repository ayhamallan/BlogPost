using Blog.DataModel.DataModels;
using Blog.DomainModel.Helpers;
using Blog.DomainModel.IServices;
using Blog.Repository.GenericRepository;
using Blog.Repository.UnitOfWork;
using Blog.Web.SignalRHub;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogPostController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<BlogPost> _repo;
        private readonly IBlogPostServie _blogPostService;
        private IHubContext<NotificationHub> _notificationHubContext;
        public BlogPostController(IUnitOfWork unit, IRepository<BlogPost> repo, IBlogPostServie blogPostServie , IHubContext<NotificationHub> notificationHubContext)
        {
            _uow = unit;
            _repo = repo;
            _blogPostService = blogPostServie;
            _notificationHubContext = notificationHubContext;
        }

        [HttpGet]
        public ActionResult<PagedResults<BlogPost>> Get(int pageNo, int rowNo)
        {
            return _blogPostService.GetPaged(pageNo , rowNo);
        }
        [NonAction]
        [AllowAnonymous]
        public IActionResult PostNotification()
        {
            return View();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<BlogPost> Get(int id)
        {
           var blogPost = _repo.Get(s => s.ID == id).FirstOrDefault();
            if (blogPost == null)
            {
                return BadRequest("Post Not Found");
            }
            else
            {
                return blogPost;
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<BlogPost> Post([FromBody] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.CreationDate = DateTime.Now;
                blogPost.Auther = !string.IsNullOrEmpty(blogPost.Auther) ? blogPost.Auther : userInfo.Name;
                _repo.Add(blogPost);
                NotificationHub notificationHub = new NotificationHub();
                _notificationHubContext.Clients.All.SendAsync("ReceiveBlog", blogPost.Auther, blogPost.Title);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BlogPost blogPost)
        {
            _blogPostService.Update(id, blogPost);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _blogPostService.Delete(id);
        }
    }
}
