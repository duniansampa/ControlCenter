using HyperAutomation.ControlRoom.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(
          UserManager<IdentityUser<Guid>> userManager,
          SignInManager<IdentityUser<Guid>> signInManager,
          IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            return $"AccountController :: {DateTime.Now.ToShortDateString()} ";
        }


        [HttpPost("Register")]
        public async Task<ActionResult<UserToken>> Register([FromBody] UserProfile model)
        {
            var user = new IdentityUser<Guid>
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Incluir o novo usuário ao perfil User
                await _userManager.AddToRoleAsync(user, "User");

                //incluir um novo usuário com email que começa com admin no perfil Admin
                if (user.Email.StartsWith("admin"))
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }

                return await GenerateTokenAsync(model);
            }
            else
            {
                return BadRequest(new { message = "Senha ou nome do usuário inválidos..." });
            }
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel loginModel)
        {
            var userProfile = new UserProfile
            {
                Password = loginModel.Password
            };

            if (this.IsEmail(loginModel.Login))
            {
                userProfile.Email = loginModel.Login;
                var user = await _userManager.FindByEmailAsync(loginModel.Login);
                if (user is not null)
                    userProfile.UserName = user.UserName;
            }else
            {
                userProfile.UserName = loginModel.Login;
                var user = await _userManager.FindByNameAsync(loginModel.Login);
                if (user is not null)
                    userProfile.Email = user.Email;
            }

            var result = await _signInManager.PasswordSignInAsync(userProfile.UserName,
               loginModel.Password, isPersistent: false, lockoutOnFailure: false);


            if (result.Succeeded)
            {
                return await GenerateTokenAsync(userProfile);
            }
            else
            {
                return BadRequest(new { message = "Login Inválido" });
            }
        }

        private async Task<UserToken> GenerateTokenAsync(UserProfile userInfo)
        {
            //var claims = new List<Claim>()
            //{
            //    new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
            //    new Claim(ClaimTypes.Name, userInfo.Email),
            //    new Claim("mac", "macoratti.net"),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};

            var user = await _signInManager.UserManager.FindByEmailAsync(userInfo.Email);
            var roles = await _signInManager.UserManager.GetRolesAsync(user);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userInfo.UserName));
            claims.Add(new Claim(ClaimTypes.Email, userInfo.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds =
               new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(2);
            var message = "Token JWT criado com sucesso";

            JwtSecurityToken token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = message
            };
        }

        private bool IsEmail(string login)
        {
            try
            {
                new System.Net.Mail.MailAddress(login);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
