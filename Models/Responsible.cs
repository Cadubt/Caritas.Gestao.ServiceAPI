using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Models
{
    public class Responsible
    {
        public int id { get; set; }
        public string responsibleName { get; set; }
        public string adress { get; set; }
        public string phone { get; set; }
        public int kinshipId { get; set; }
    }
}
