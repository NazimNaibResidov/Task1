using ExamApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Core.Extensions
{
    public static class LessonExtensions
    {
        public static async Task<bool> HasLessonAsync(this DbSet<Lesson> lessons, string code)
        {
            return await lessons.AnyAsync(x => x.Code == code);
        }
    }
}
