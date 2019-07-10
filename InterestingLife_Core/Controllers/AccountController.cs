using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace InterestingLife_Core.Controllers
{
 
    [Produces("application/json")]
    //[Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IAccount _account;

        public AccountController(IAccount account) => _account = account;

        [HttpGet]
        [Route("/api/account/index")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [Route("/api/login")]
        public IActionResult LogIn()
        {
            return View();
        }
       
        [HttpPost]
        [Route("/api/adduser")]
        public async Task Registration( AccountModel newUser)
        {
            if (newUser == null) await Response.WriteAsync("");
            _account.Registration(newUser);

            var identity = GetIdentity(newUser);
            if (identity == null)
            {
                await Response.WriteAsync("Логин или пароль неверный");
            }
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
                );

            AccountInfoModel accountInfoModel = _account.GetAccountInfo(newUser);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            accountInfoModel.Token = encodedJwt;

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(encodedJwt,
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

     

        
        [HttpPost]
        [Route("/api/gettoken")]
        public async Task GetToken( AccountModel account)
        {
            var identity = GetIdentity(account);
            if (identity == null)
            {
                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(new SimpleResponse("Неверный логин или пароль"),
                    new JsonSerializerSettings { Formatting = Formatting.Indented }));
                return;
            }
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
                );

            AccountInfoModel accountInfoModel = _account.GetAccountInfo(account);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            accountInfoModel.Token = encodedJwt;
            var response = new
            {
                access_token = encodedJwt,
                userName = identity.Name
            };
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(new SimpleResponse(response),
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }



        private ClaimsIdentity GetIdentity(AccountModel account)
        {
            if (_account.IsAuthorized(account))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, account.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, account.Role.Name),
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Token",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }
            return null;
        }
    }
}