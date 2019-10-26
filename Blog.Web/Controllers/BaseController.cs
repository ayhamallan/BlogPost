using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Web.Controllers
{
    public class UserInfo
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
  
    public class BaseController : Controller
    {
        public UserInfo userInfo { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            GetUserInfo();
        }
        [NonAction]
        public void GetUserInfo()
        {

            var user = (HttpContext.User.Identity as ClaimsIdentity);
            if (user.Claims.Count() > 0)
            {
                userInfo = new UserInfo
                {
                    UserID = user.FindFirst("sub").Value,
                    UserName = user.FindFirst("email").Value,
                    Name = user.FindFirst("Name").Value,
                };
            }

        }
    }
}