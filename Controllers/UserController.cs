using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Caritas.Gestao.ServiceAPI.Interfaces;
using Caritas.Gestao.ServiceAPI.Models;
using Caritas.Gestao.ServiceAPI.Context;

namespace Caritas.Gestao.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public readonly CaritasContext _context;

        public UserController(CaritasContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        

        /// <summary>
        /// Get Usuarios
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("todos")]
        public ActionResult GetUsers()
        {
            try
            {
                List<User> u = _userService.GetUsers();
                return Ok(u);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        /// <summary>
        /// Get an specific user by his name
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("GetUser")]
        public ActionResult GetUser(string nome)
        {
            try
            {
                var userFound = _userService.GetUser(nome);
                return Ok(userFound);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        /// <summary>
        /// Responsible to Create an User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        public ActionResult PostUsers([FromBody] User user)
        {
            try
            {
                bool wasCreated = _userService.PostUsers(user);
                if (!wasCreated)
                    return BadRequest($"Error: Nenhum usuario foi enviado para ser cadastrado");

                return Ok("OK");
            }
            catch (Exception)
            {
                return BadRequest($"Error: Nenhum usuario foi enviado para ser cadastrado");
            }
        }

        /// <summary>
        /// Responsible to Update an User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("UpdateUser")]
        public ActionResult PutUser(User user)
        {
            try
            {
                var userFound = _userService.PutUser(user);

                if (userFound != null)
                    return Ok(user);

                return BadRequest("A Pesquisa não encontrou nenhum resultado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        /// <summary>
        /// Responsible to Delete an User by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult DeleteUsers(int id)
        {
            try
            {
                _userService.DeleteUsers(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }




    }
}