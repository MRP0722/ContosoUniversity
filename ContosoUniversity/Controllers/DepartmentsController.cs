using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Data;
using ContosoUniversity.Data;
using ContosoUniversity.Helper;

namespace ContosoUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
        private SchoolContext _context;

        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() {
            return Json(_context.Students);
        }
    }
}