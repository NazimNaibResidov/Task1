using ExamApp.Core.Extensions;
using ExamApp.Core.Services.Contracts;
using ExamApp.Core.Services.ServiceModels;
using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ExamApp.Core.Services.Implt
{
    public class ExamAppLessonService : ILessonService
    {
        /// <summary>
        /// inject dbContext
        /// </summary>
        private readonly ExamDbContext _examDbContext;
        public ExamAppLessonService(ExamDbContext examDbContext)
        {
            _examDbContext = examDbContext;
        }

        /// <summary>
        /// Register given lesson..
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public async Task<RegistrationResult> RegisterAsync(Lesson lesson)
        {
            RegistrationResult registrationResult = null;
            //check if lesson exists
            bool isLessonExists = await _examDbContext.Lessons.HasLessonAsync(lesson.Code);

            //if exists then error...
            if (isLessonExists)
            {
                registrationResult = new RegistrationResult(false)
                {
                    ErrorMessages = new List<string>
                     {
                         "Lesson with given code already exists"
                     }
                };
            }
            else
            {
                try
                {
                    await _examDbContext.Lessons.AddAsync(lesson);
                    await _examDbContext.SaveChangesAsync();
                    registrationResult = new RegistrationResult(true);

                }
                catch (Exception exp)
                {
                    throw exp;
                }

            }
            return registrationResult;
        }
    }
}
