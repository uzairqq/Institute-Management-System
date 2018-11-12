using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sms.Domain.Dto;
using Sms.Domain.Entities;
using Sms.Services.Service.Interfaces;

namespace Sms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        /// <summary>
        /// Add Student
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("addStudent")]
        public async Task<IActionResult> Add(StudentDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var student = await _studentService.AddStudent(dto);
                return Ok(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// GetAll Student
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var stu = await _studentService.GetAll();
                return Ok(stu);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Get Student By StudentId
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                if (id == 0) return BadRequest("Id Not Valid");
                var result = await _studentService.GetById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        /// <summary>
        /// Delete Student
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(StudentDto dto)
        {
            try
            {
                if (dto.Id == 0) return BadRequest("Id Not Valid");
                var result = await _studentService.DeleteStudent(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Update Student
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(StudentDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var result = await _studentService.UpdateStudent(dto);
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