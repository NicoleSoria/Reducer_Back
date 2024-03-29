﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Todo.API.Data;
using Todo.API.Dto;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
       

        public AuthController(IAuthRepository repo, IConfiguration config )
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(DtoRegisterUser userDto)
        {
            userDto.UserName = userDto.UserName.ToLower();

            if (await _repo.UserExist(userDto.UserName))
                return BadRequest("Usuario existente");

            var createToUser = new User
            {
                UserName = userDto.UserName,
                Nombre = userDto.Nombre,
                Apellido = userDto.Apellido
            };

            var createdUser = await _repo.Register(createToUser, userDto.Password);

            return StatusCode(201);
               
        }

        [HttpPost("loguin")]
        public async Task<IActionResult> Loguin(DtoLoguinUser loguinDto)
        {
            var userFromRepo = await _repo.Login(loguinDto.UserName, loguinDto.Password);

            if(userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            //Obtener el token de la configuracion
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }

        [HttpPost("google")]
        public async Task<IActionResult> GoogleSingIn(){

            return StatusCode(200);
        }
    }
}
