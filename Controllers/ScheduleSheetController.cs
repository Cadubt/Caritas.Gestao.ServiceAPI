using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.Gestao.ServiceAPI.Context;
using Caritas.Gestao.ServiceAPI.Interfaces;
using Caritas.Gestao.ServiceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caritas.Gestao.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleSheetController : ControllerBase
    {
        private readonly IScheduleSheetService _scheduleSheetService;

        public readonly CaritasContext _context;

        public ScheduleSheetController(CaritasContext context, IScheduleSheetService scheduleSheetService)
        {
            _context = context;
            _scheduleSheetService = scheduleSheetService;
        }

        [HttpGet("GetAll")]
        public ActionResult GetScheduleSheets()
        {
            try
            {
                List<ScheduleSheet> sheets = _scheduleSheetService.GetScheduleSheets();
                return Ok(sheets);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpPost("Create")]
        public ActionResult PostScheduleSheet(ScheduleSheet scheduleSheet)
        {
            try
            {
                bool wasCreated = _scheduleSheetService.PostScheduleSheet(scheduleSheet);
                if (!wasCreated)
                    return BadRequest($"Error: Nenhuma Ficha de Agendamento foi enviada para ser cadastrado");

                return Ok("OK");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpGet("GetOne")]
        public ActionResult GetScheduleSheet(int id)
        {
            try
            {
                var ScheduleSheetFound = _scheduleSheetService.GetScheduleSheet(id);
                return Ok(ScheduleSheetFound);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }
    }
}