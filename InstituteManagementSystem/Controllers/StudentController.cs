using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstituteManagementSystem.Models;

namespace InstituteManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController()
        {
            _context=new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpPost]
        public ActionResult Save(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index","Student");
        }


        // GET: Student
        public ActionResult Index()
        {
            var students= _context.Students.ToList();
            return View(students);
        }



        public ActionResult New()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var student = _context.Students.Single(i => i.Id == id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        public ActionResult Edit()
        {
            return View();
        }

    }
}