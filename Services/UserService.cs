using Caritas.Gestao.Domain;
using Caritas.Gestao.ServiceAPI.Context;
using Caritas.Gestao.ServiceAPI.Interfaces;
using Caritas.Gestao.ServiceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Services
{
    public class UserService : IUserService
    {
        public readonly CaritasContext _context;

        public UserService(CaritasContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            List<User> u = new List<User>();
            u = _context.Users.ToList();
            return u;
        }

        public object GetUser(string nome)
        {
            var userFound = from user in _context.Users where user.Name == nome select user;
            return userFound;
        }

        public bool PostUsers(User user)
        {
            if (user == null)
                return false;

            var createdUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };

            _context.Users.Update(createdUser);
            _context.SaveChanges();

            return true;
        }

        public User PutUser(User user)
        {
            var userFound = _context.Users.AsNoTracking().FirstOrDefault(
                    u => u.Id == user.Id);

            if (userFound == null)
                return userFound;

            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUsers(int id)
        {
            var user = _context.Users.Where(u => u.Id == id).Single();

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
