using AutoMapper;
using DesafioToro.Application.Contracts;
using DesafioToro.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioToro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("insertUser")]
        public async Task<IActionResult> InsertUser(UserDto model)
        {
            try
            {
                var user = await _userService.AddUser(model);
                if (user == null) return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                       $"Post: Erro ao inserir Usuário. Erro: {ex.Message}");               
            }
        }
    }
}
