using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("index/data")]
        //public async Task<IActionResult> IndexData()
        //{
        //    //var students = Get();
        //    return Json(new { data = students });
        //}

        

        [Route("New")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(StudentDto stu)
        {
            try
            {
                var status = false;
                if (stu.Id != 0)
                    await _studentService.UpdateStudent(stu);
                else
                    await _studentService.AddStudent(stu);
                status = true;
                return Ok();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("Delete")]
        public async Task<IActionResult> Delete(StudentDto dto)
        {
            if (dto == null)
            {
                return NotFound();
            }
            var student = await _studentService.DeleteStudent(dto);

            if (student == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Student");
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

        //[Route("grid")]
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        return Json(new { data = await _studentService.GetAll() });
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine();
        //        throw;
        //    }
        //}
    }


}