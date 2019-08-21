using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Students
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Students.ToListAsync());
        //}

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult List()
        {

            return Json(_context.Students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost,ActionName("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("EnrollmentDate,FirstMidName,LastName")]
        Student student)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("errcode", 0);
            dic.Add("errmsg", "ok");
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                }
                else {
                    dic["errcode"] = 1;
                    dic["errmsg"] = "ModelState.IsValid fail";
                }
            }
            catch(DbUpdateException ex){
                dic["errcode"] = -1;
                dic["errmsg"] = "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.";
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return Json(dic);
        }

        public IActionResult Edit(int id) {
            Student student = _context.Students.Where(p => p.ID.Equals(id)).First();
            return View(student);
        }

        public IActionResult Update(Student student) {
            return Json("");
        }
    }
}