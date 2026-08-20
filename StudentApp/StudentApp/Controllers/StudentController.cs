using Microsoft.AspNetCore.Http.HttpResults;
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
        public IActionResult Index(string query, string sortOrder)
        {
            var filteredList = _students.AsEnumerable();

            if (!string.IsNullOrEmpty(query))
            {
                 filteredList = filteredList.Where(s => s.Name.ToLower().Contains(query.ToLower()));
            }

            switch(sortOrder)
            {
                case "title_asc":
                    filteredList = filteredList.OrderBy(s => s.Name);
                    break;
                case "title_desc":
                    filteredList = filteredList.OrderByDescending(s => s.Name);
                    break;
            }

            var studentVM = new StudentViewModel
            {
                Students = filteredList.ToList()
            };

            return View(studentVM);
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
