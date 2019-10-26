using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult PostNotification()
        {
            return View();
        }
    }
}