using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRM_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using CRM_DB;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CRM_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public UserController (IConfiguration config)
        {
            this.configuration = config;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserAuth userDto)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            User user;
            using (UserDac dac = new UserDac(connStr))
            {
                user = dac.Authenticate(userDto.login, userDto.password);
            }
                

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("superSecretKey@345");
            var tokenDescriptor = new SecurityTokenDescriptor
           {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.userid.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.userid,
                login = user.login,
                Onoma = user.firstname,
                Eponimo = user.lastname,
                Token = tokenString
            });
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]User userDto)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            bool success;
            
            using (UserDac dac = new UserDac(connStr))
            {
                success  = dac.Register(userDto);
                //success = true;
            }

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
               result = success
            });
        }
    }
}