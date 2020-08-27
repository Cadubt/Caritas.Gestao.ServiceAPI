using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Models
{
    public class ScheduleSheet
    {
        public int id { get; set; }
        public string shelteredName { get; set; }
        public int shelteredAge { get; set; }
        public string shelteredPhone { get; set; }

        public string shelteredAddress { get; set; }
        public string responsibleName { get; set; }

        /// <summary>
        /// Grau de parentesco
        /// </summary>
        public int kinshipId { get; set; }
        public string responsiblePhone { get; set; }
        public string responsibleAddress { get; set; }
        public DateTime interviewDate { get; set; }
        public DateTime scheduleDate { get; set; }
        public string observation { get; set; }
        public string scheduleResponsible { get; set; }

    }
}
