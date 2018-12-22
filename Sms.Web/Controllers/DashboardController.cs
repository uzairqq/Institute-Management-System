using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sms.Web.ViewModels;

namespace Sms.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var totalDashboardEntities = new DashboardTotalEntitiesCount();

            return View(totalDashboardEntities);
        }
    }
}