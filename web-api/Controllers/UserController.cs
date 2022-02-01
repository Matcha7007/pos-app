using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using web_api.Dtos;
using web_api.Errors;
using web_api.Extensions;
using web_api.Interfaces;
using web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace web_api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;

        public UserController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
        }   

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);
            
            ApiError apiError = new ApiError();
            
            if (user == null)
            {
                apiError.ErrorCode = Unauthorized().StatusCode;
                apiError.ErrorMessage = "Invalid User ID or Password";
                apiError.ErrorDetails = "This error eppear when provide user id or password does not exist";
                return Unauthorized(apiError);
            }
            var loginRes = new LoginResDto();
            loginRes.UserName = user.Username;
            loginRes.Token = CreateJWT(user);
            loginRes.UserRole = user.UserRole;
            return Ok(loginRes);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterReqDto registerDto)
        {
            ApiError apiError = new ApiError();

            if(registerDto.UserName.IsEmty() || registerDto.Password.IsEmty())
                {
                    apiError.ErrorCode = BadRequest().StatusCode;
                    apiError.ErrorMessage = "Username or password can't be blank";
                    return BadRequest(apiError);
                }
            if (await uow.UserRepository.UserAlreadyExists(registerDto.UserName))
                {
                    apiError.ErrorCode = BadRequest().StatusCode;
                    apiError.ErrorMessage = "User already exist. pleas try different username";
                    return BadRequest(apiError);
                }
            
            uow.UserRepository.Register(registerDto.UserName, registerDto.Password, registerDto.UserRole);
            await uow.SaveAsync();
            return StatusCode(201);
            
        }

        private string CreateJWT(User user)
        {
            var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                key,SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}