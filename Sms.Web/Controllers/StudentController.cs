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

        public async Task<IActionResult> Index()
        {
            var stu = await _studentService.GetAll();
            return View(stu);
        }

        [Route("New")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("PostData")]
        public async Task<IActionResult> PostData(StudentDto stu)
        {
            try
            {
                if (!ModelState.IsValid) return RedirectToAction("Index", "Student");
                if (stu.Id != 0)
                    await _studentService.UpdateStudent(stu);
                else
                    await _studentService.AddStudent(stu);
                return RedirectToAction("Index", "Student");
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
            var result = await _studentService.GetById(id);
            return View("Update", result);
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