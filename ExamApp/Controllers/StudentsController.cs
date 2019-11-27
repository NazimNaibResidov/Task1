using ExamApp.Core.Services.Contracts;
using ExamApp.Core.Services.ServiceModels;
using ExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(Student student)
        {
            if (ModelState.IsValid)
            {
                RegistrationResult registrationResult = await _studentService.RegisterAsync(student);
                if (registrationResult.IsSucceeded)
                {
                    return RedirectToAction("Register", new { controller = "Exams" });
                }
                else
                {
                    ViewBag.Errors = registrationResult.ErrorMessages;
                    return View();
                }


            }
            else
                return View();

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
