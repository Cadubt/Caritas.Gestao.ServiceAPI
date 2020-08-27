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
    }
}
