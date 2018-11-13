using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sms.Domain.Dto;
using Sms.Services.Service.Interfaces;

namespace Sms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Post([FromBody] EmployeeDto dto)
        {
            try
            {
                var result = await _employeeService.AddEmployee(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IActionResult> Put([FromBody] EmployeeDto dto)
        {
            try
            {
                var result = await _employeeService.UpdateEmployee(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _employeeService.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _employeeService.GetById(id);
            return Ok(result);
        }

        public async Task<IActionResult> Delete(EmployeeDto dto)
        {
            try
            {
                var result = await _employeeService.DeleteEmployee(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}