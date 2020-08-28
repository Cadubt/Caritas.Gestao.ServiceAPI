using Caritas.Gestao.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Interfaces
{
    public interface IScheduleSheetService
    {
        public List<ScheduleSheet> GetScheduleSheets();
        public bool PostScheduleSheet(ScheduleSheet scheduleSheet);
        public object GetScheduleSheet(int id);
    }
}
