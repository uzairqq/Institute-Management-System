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
    public class EmployeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeService _employeeTypeService;

        public EmployeTypeController(IEmployeeTypeService studentService)
        {
            _employeeTypeService = studentService;
        }
        /// <summary>
        /// Add EmployeeType
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("addEmployeeType")]
        public async Task<IActionResult> Add(EmployeTypeDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var employeeType = await _employeeTypeService.AddEmployeType(dto);
                return Ok(employeeType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// GetAll EmployeeType
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var employeeType = await _employeeTypeService.GetAll();
                return Ok(employeeType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Get EmployeeType By EmployeeTypeId
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id Not Valid");
                var result = await _employeeTypeService.GetById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        /// <summary>
        /// Delete EmployeeType
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(EmployeTypeDto dto)
        {
            try
            {
                if (dto.Id == 0) return BadRequest("Id Not Valid");
                var result = await _employeeTypeService.DeleteEmployeType(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Update Employee Type
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(EmployeTypeDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var result = await _employeeTypeService.UpdateEmployeType(dto);
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