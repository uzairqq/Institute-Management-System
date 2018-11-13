using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sms.Domain.Dto;
using Sms.Services.Service.Interfaces;

namespace Sms.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _teacherService.GetAll();
            return View(result);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("PostData")]
        public async Task<IActionResult> PostData(EmployeeDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return RedirectToAction("Index", "Teacher");
                if (dto.Id != 0)
                    await _teacherService.UpdateTeacher(dto);
                else
                    await _teacherService.AddTeacher(dto);
                return RedirectToAction("Index", "Teacher");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [Route("Update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _teacherService.GetById(id);
            return View("Update", result);
        }

        [HttpGet]
        [Route("Delete")]
        public async Task<IActionResult> Delete(EmployeeDto dto)
        {
            if (dto == null)
            {
                return NotFound();
            }

            var teacher = await _teacherService.DeleteTeacher(dto);

            if (teacher == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Teacher");

        }


    }
}