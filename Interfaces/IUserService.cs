using Caritas.Gestao.Domain;
using Caritas.Gestao.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Interfaces
{
    public interface IUserService
    {
        public List<User> GetUsers();

        public object GetUser(string nome);

        public bool PostUsers(User user);

        public User PutUser(User user);

        public void DeleteUsers(int id);
    }
}
