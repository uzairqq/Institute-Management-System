using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sms.Domain.Dto;
using Sms.Services.Service.Interfaces;

namespace Sms.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _employeeService.GetAll();
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
                if (!ModelState.IsValid) return RedirectToAction("Index", "Employee");
                if (dto.Id != 0)
                    await _employeeService.UpdateEmployee(dto);
                else
                    await _employeeService.AddEmployee(dto);
                return RedirectToAction("Index", "Employee");
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
            var result = await _employeeService.GetById(id);
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

            var employee = await _employeeService.DeleteEmployee(dto);

            if (employee == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Employee");

        }


    }
}