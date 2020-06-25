using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Models.Entities
{
    public class UserModel
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Password { get; set; }
    }
}
