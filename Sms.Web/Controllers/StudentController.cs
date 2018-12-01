using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCaching.Internal;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sms.Domain.Dto;
using Sms.Services.Service.Interfaces;

namespace Sms.Web.Controllers
{
    [Route("[Controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _studentService.GetAll();
            return View(result);
        }



        [Route("New")]
        public IActionResult New()
        {
            return View();
        }

        [HttpGet("grid")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Json(new { data = await _studentService.GetAll() });
            }
            catch (Exception)
            {
                Console.WriteLine();
                throw;
            }
        }

        //[HttpGet("index/data")]
        //public async Task<IActionResult> IndexData()
        //{
        //    var students =await Get();
        //    return Json(new { data = students });
        //}
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]StudentDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var serviceCall = await _studentService.AddStudent(dto);
                return Json(serviceCall);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<JsonResult> Get(int id)
        {
            return Json(new { data = await _studentService.GetById(id) });
            //var result = await _studentService.GetById(id);
            ////return Json(result);
        }



        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] StudentDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (dto.Id != 0) return Json(await _studentService.UpdateStudent(dto));
                return Json(await _studentService.AddStudent(dto));


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (dto == null)
            {
                return NotFound();
            }
            var student = await _studentService.DeleteStudent(dto);

            if (student == null)
            {
                return NotFound();
            }

            return Json(student);
            //return RedirectToAction("Index", "Student");
        }
        [Route("Update")]
        public async Task<IActionResult> Update(int id)
        {
            //var result = await _studentService.GetById(id);
            return View("Update");
        }






        //public async Task<StudentDto> Get(int id)
        //{
        //    var result = await _studentService.GetById(id);
        //    return result;
        //}


    }


}