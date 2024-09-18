// WebApp/Controllers/StudentsController.cs
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Service.Interface;

public class StudentsController : Controller
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // Action to show the student registration form
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Action to handle the form submission
    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid)
            return View(student);

        _studentService.RegisterStudent(student.FirstName, student.LastName, student.NationalCode, student.BirthYear);

        return RedirectToAction("Success");
    }

    // Action to show success page after registration
    public IActionResult Success()
    {
        return View();
    }
}
