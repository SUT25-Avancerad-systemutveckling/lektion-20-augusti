using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> _students = new()
        {
            new Student
            {
                Id = 1, Name = "Ada", Program = "Backend Dev"
            },
            new Student
            {
                Id = 2, Name = "Grace", Program = "Frontend Dev"
            },
        };
        public IActionResult Index()
        {
            return View(_students);
        }

        public IActionResult Add() { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Add([Bind("Name, Program")] Student student)
        {
            if (ModelState.IsValid)
            {
                _students.Add(new Student
                {
                    Id = _students.Count + 1,
                    Name = student.Name,
                    Program = student.Program
                });

                return RedirectToAction("Index");
            }

            return View(student);
        }
    }
}
