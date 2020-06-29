using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.Gestao.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPut("{id}")]
        public void PutUsers(int id)
        {

        }

        [HttpPost("{id}")]
        public void PostUsers(int id)
        {

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