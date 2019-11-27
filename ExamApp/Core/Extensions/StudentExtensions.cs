using ExamApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Core.Extensions
{
    public static class StudentExtensions
    {
        public static async Task<bool> HasStudentAsync(this DbSet<Student> students, int number)
        {
            return await students.AnyAsync(x => x.Number == number);
        }
    }
}
