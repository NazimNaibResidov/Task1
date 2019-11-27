using ExamApp.Core.Extensions;
using ExamApp.Core.Services.Contracts;
using ExamApp.Core.Services.ServiceModels;
using ExamApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ExamApp.Core.Services.Implt
{
    public class ExamAppExamService : IExamService
    {
        /// <summary>
        /// inject dbContext
        /// </summary>
        private readonly ExamDbContext _examDbContext;
        public ExamAppExamService(ExamDbContext examDbContext)
        {
            _examDbContext = examDbContext;
        }

        public async Task<ExamViewModel> GetRequiredDatasAsync()
        {
           return new ExamViewModel
            {
                StudentNumbers =await _examDbContext.Students.Select(x => x.Number).ToListAsync(),
                LessonCodes =await _examDbContext.Lessons.Select(x => x.Code).ToListAsync()
           };
            
        }

        /// <summary>
        /// Register given lesson..
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public async Task<RegistrationResult> RegisterAsync(Exam exam)
        {
            RegistrationResult registrationResult = null;
                try
                {
                    await _examDbContext.Exams.AddAsync(exam);
                    await _examDbContext.SaveChangesAsync();
                    registrationResult = new RegistrationResult(true);

                }
                catch (Exception exp)
                {
                    throw exp;
                }
            return registrationResult;
        }
    }
}
