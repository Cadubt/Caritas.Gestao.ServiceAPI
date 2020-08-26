using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.Gestao.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Caritas.Gestao.ServiceAPI.Interfaces;
using Caritas.Gestao.ServiceAPI.Models;
using System.Collections.Immutable;
using Caritas.Gestao.ServiceAPI.Context;

namespace Caritas.Gestao.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //private readonly IUserService userService;

        public readonly CaritasContext _context;

        public UserController(CaritasContext context)
        {
            _context = context;
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
                List<User> u = new List<User>();
                u = _context.Users.ToList();
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
                var userFound = from user in _context.Users where user.Name == nome select user;
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
                if (user == null)
                    return BadRequest("Nenhum usuario foi enviado para ser cadastrado");

                var createdUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    Role = user.Role
                };

                _context.Users.Update(createdUser);
                _context.SaveChanges();

                return Ok("OK");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
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
                var userFound = _context.Users.AsNoTracking().FirstOrDefault(
                    u => u.Id == user.Id);

                if (userFound != null)
                {
                    _context.Users.Update(user);
                    _context.SaveChanges();
                    return Ok(user);
                }
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
        public void DeleteUsers(int id)
        {
            var user = _context.Users.Where(u => u.Id == id).Single();

            _context.Users.Remove(user);
            _context.SaveChanges();
        }




    }
}