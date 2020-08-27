using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Models
{
    public class Sheltered
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public DateTime birthDate { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int bloodTyping { get; set; }        
        public DateTime entryDate { get; set; }
        public string perfilImage { get; set; }
    }
}
