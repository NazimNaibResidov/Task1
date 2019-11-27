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
    public class ExamsController : Controller
    {
        private readonly IExamService _examService;
        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(Exam exam)
        {
            if (ModelState.IsValid)
            {
                RegistrationResult registrationResult = await _examService.RegisterAsync(exam);
                if (registrationResult.IsSucceeded)
                {
                    return RedirectToAction("Register", new { controller = "Exams" });
                }
                else
                    return View();

            }
            else
                return View();

        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
           var datas = await _examService.GetRequiredDatasAsync();
            return View(datas);
        }
    }
}
