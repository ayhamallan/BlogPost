using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Security.Infrastructure.Models;
using Blog.Security.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Security.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<BlogUser> _userManager;

        public AccountController(UserManager<BlogUser> userManager)//, IEventBus eventBus
        {
            _userManager = userManager;

        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Register([FromBody]RegisterRequestVM model)
        {
            //var aVal = 0; var blowUp = 1 / aVal;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new BlogUser
            {
                UserName = model.Email,
                Name = model.Name,
                Email = model.Email,
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded) return BadRequest(result.Errors);
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("Id", user.Id));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("name", user.Name));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", "User"));
            }
            catch (Exception ex)
            {
                return BadRequest("National code already exist!");
            }
            return Ok(new RegisterResponseVM(user));
        }
    }
}