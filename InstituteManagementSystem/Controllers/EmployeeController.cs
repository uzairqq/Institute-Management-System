using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstituteManagementSystem.Models;

namespace InstituteManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeController()
        {
            _dbContext=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employee = _dbContext.Employees.ToList();
            return View(employee);
        }

        public ActionResult New()
        {
            throw new NotImplementedException();
        }
    }
}