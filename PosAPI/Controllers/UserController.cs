using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PosAPI.Dtos;
using PosAPI.Errors;
using PosAPI.Extensions;
using PosAPI.Interfaces;
using PosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace PosAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration config;
        public UserController(IUnitOfWork uow, IConfiguration config)
        {
            this.config = config;
            this.uow = uow;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Signin(SigninReqDto signinReq)
        {
            var user = await uow.UserRepository.Authenticate(signinReq.UserName, signinReq.Password);
            ApiError apiError = new ApiError();
            if (user == null)
            {
                apiError.ErrorCode=Unauthorized().StatusCode;
                apiError.ErrorMessage="Invalid user name or password";
                apiError.ErrorDetails="This error appear when provided user id or password does not exists";
                return Unauthorized(apiError);
            }
            var signinRes = new SigninResDto();
            signinRes.UserName = user.UserName;
            signinRes.Token = CreateJWT(user);
            signinRes.UserRole = user.UserRole;
            return Ok(signinRes);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register(SignupReqDto signupReq)
        {
            ApiError apiError = new ApiError();

            if(signupReq.UserName.IsEmty() || signupReq.Password.IsEmty()) {
                    apiError.ErrorCode=BadRequest().StatusCode;
                    apiError.ErrorMessage="User name or password can not be blank";                    
                    return BadRequest(apiError);
            }                    

            if (await uow.UserRepository.UserAlreadyExists(signupReq.UserName)) {
                apiError.ErrorCode=BadRequest().StatusCode;
                apiError.ErrorMessage="User already exists, please try different user name";
                return BadRequest(apiError);
            }                

            uow.UserRepository.Signup(signupReq.UserName, signupReq.Password, signupReq.UserRole);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        private string CreateJWT(User user)
        {
            var secretKey = config.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}