using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SupplierProject.Application.DTO.User;

namespace SupplierProject.Services.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterUserDTO registerUser)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(registerUser);
            }

            return BadRequest(new
            {
                statusCode = 400,
                errors = result.Errors
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(loginUser);
            }

            if (result.IsLockedOut)
            {
                return BadRequest(new
                { 
                    statusCode = 400,
                    message = "Usuário temporariamente bloqueado"
                });
            }

            return BadRequest(new
            {
                statusCode = 400,
                message = "Email e/ou senha incorretos"
            });
        }
    }
}