using Caritas.Gestao.ServiceAPI.Context;
using Caritas.Gestao.ServiceAPI.Interfaces;
using Caritas.Gestao.ServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Services
{
    public class ScheduleSheetService : IScheduleSheetService
    {
        public readonly CaritasContext _context;

        public ScheduleSheetService(CaritasContext context)
        {
            _context = context;
        }


        public List<ScheduleSheet> GetScheduleSheets()
        {
            List<ScheduleSheet> ss = new List<ScheduleSheet>();
            ss = _context.ScheduleSheets.ToList();
            return ss;
        }
        public bool PostScheduleSheet(ScheduleSheet scheduleSheet)
        {
            if (scheduleSheet == null)
                return false;

            var createdscheduleSheet = new ScheduleSheet
            {
                interviewDate = scheduleSheet.interviewDate,
                kinshipId = scheduleSheet.kinshipId,
                observation = scheduleSheet.observation,
                responsibleAddress = scheduleSheet.responsibleAddress,
                responsibleName = scheduleSheet.responsibleName,
                responsiblePhone = scheduleSheet.responsiblePhone,
                scheduleDate = scheduleSheet.scheduleDate,
                scheduleResponsible = scheduleSheet.scheduleResponsible,
                shelteredAddress = scheduleSheet.shelteredAddress,
                shelteredAge = scheduleSheet.shelteredAge,
                shelteredName = scheduleSheet.shelteredName,
                shelteredPhone = scheduleSheet.shelteredPhone

            };

            _context.ScheduleSheets.Update(createdscheduleSheet);
            _context.SaveChanges();

            return true;
        }
        public object GetScheduleSheet(int id) 
        {
            var ScheduleSheetFound = from ss in _context.ScheduleSheets where ss.id == id select ss;
            return ScheduleSheetFound;
        }
    }
}
