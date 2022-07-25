using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Web_API.Entities;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly UserManager<Account> _userManager;
        //private readonly JWT _jwt;
        public AccountsController(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccount request)
        {
            var usernameHasBeenUsed = _userManager.Users.Any(e => e.UserName == request.Username);

            if (usernameHasBeenUsed)
                return Accepted();

            var student = new Student()
            {
                Name = request.Name,
                Gender = request.Gender,
                Phone = request.Phone,
                Address = request.Address
            };
            var account = new Account { UserName = request.Username, Student = student};

            _ = await _userManager.CreateAsync(account, request.Password);
            _ = await _userManager.AddToRoleAsync(account, "student");

            return Created(string.Empty, null);
        }
        [Authorize]
        [Route("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");

            return NoContent();
        }
    }
    }
}
