using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.Gestao.Domain;
using Caritas.Gestao.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caritas.Gestao.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public CaritasContext _context { get; set; }
        public UserController(CaritasContext context)
        {
            _context = context;
        }


        [HttpGet("filtro/{nome}")]
        public ActionResult GetUsers(string nome)
        {
            try
            {
                #region LINQ Method
                var listUsers = _context.Users.Where(u => u.Name.Contains(nome)).ToList();
                #endregion

                #region LINQ Query
                //var listUsers = (from user in _context.Users
                //                 where user.Name.Contains(nome)
                //                 select user).ToList();
                #endregion

                return Ok(listUsers);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpGet("GetUser")]
        public ActionResult GetUser(string nome)
        {
            try
            {
                return Ok(new UserModel());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }


        [HttpPost("{id}")]
        public ActionResult PostUsers([FromBody] UserModel user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok("OK");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }


        [HttpPut("PutUser/{id}")]
        public ActionResult PutUser(int id, UserModel user)
        {
            try
            {
                if (_context.Users.AsNoTracking().FirstOrDefault(
                    u => u.Id == id) != null)
                {
                    _context.Users.Update(user);
                    _context.SaveChanges();
                    return Ok(user);
                }
                return Ok("A Pesquisa não encontrou nenhum resultado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }


        [HttpDelete("{id}")]
        public void DeleteUsers(int id)
        {
            var user = _context.Users.Where(u => u.Id == id).Single();

            _context.Users.Remove(user);
            _context.SaveChanges();

        }


    }
}