using ExamApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Core.Extensions
{
    public static class ExamExtensions
    {
        public static async Task<bool> HasExamAsync(this DbSet<Exam> exams, string lessonCode)
        {
            return await exams.AnyAsync(x => x.LessonCode == lessonCode);
        }
    }
}
