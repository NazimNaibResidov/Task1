using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Controllers
{
    public class ShowController : Controller
    {
        private readonly ExamDbContext context;

        public ShowController(ExamDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            var data = context.Exams.Include(x => x.Lesson)
                .Include(x => x.Student).ToList();
            return View(data);
        }
    }
}