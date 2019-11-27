using ExamApp.Core.Services.Contracts;
using ExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApp.Core.Services.ServiceModels;
namespace ExamApp.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonService _lessonService;
        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                RegistrationResult registrationResult = await _lessonService.RegisterAsync(lesson);
                if (registrationResult.IsSucceeded)
                {
                    return RedirectToAction("Register", new { controller = "Students" });
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
