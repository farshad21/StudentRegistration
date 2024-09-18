// WebApp/Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Service.Interface;
using Service.Service;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Create Student (GET & POST)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            _studentService.RegisterStudent(student.FirstName, student.LastName, student.NationalCode, student.BirthYear);
            return RedirectToAction("Index");
        }

        // Get All Students
        [HttpGet]
        public IActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }

        // Update Student (GET & POST)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            _studentService.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        // Delete Student (GET & POST)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
