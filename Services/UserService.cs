using Caritas.Gestao.Domain;
using Caritas.Gestao.ServiceAPI.Context;
using Caritas.Gestao.ServiceAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Services
{
    public class UserService : IUserService
    {

        public CaritasContext _context { get; set; }

        //public List<UserModel> GetUsers()
        //{
        //    #region LINQ Method
        //        //var listUsers = _context.Where(u => u.Name.Contains(nome)).ToList();
        //        #endregion

        //        #region LINQ Query
        //        var listUsers = (from user in _context.Users
        //                         select user).ToList();
        //        #endregion

        //    return listUsers;
        //}
    }
}
