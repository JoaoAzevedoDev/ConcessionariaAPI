﻿using Concessionaria.API.Interfaces;
using Concessionaria.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IJwtTokenManager _tokenManager;

        public UserController(IJwtTokenManager jwtTokenManager)
        {
            _tokenManager = jwtTokenManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateUser(string userName, string password)
        {
            var user = new UserCredential(userName, password);
            var token = _tokenManager.CreateNewUser(user);
            if (token == false)
                return BadRequest("Usuário não criado!");
            return Ok("Usuário criado com sucesso!");
        }
    }
}
