using ExamApp.Core.Extensions;
using ExamApp.Core.Services.Contracts;
using ExamApp.Core.Services.ServiceModels;
using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ExamApp.Core.Services.Implt
{
    public class ExamAppStudentService : IStudentService
    {
        /// <summary>
        /// inject dbContext
        /// </summary>
        private readonly ExamDbContext _examDbContext;
        public ExamAppStudentService(ExamDbContext examDbContext)
        {
            _examDbContext = examDbContext;
        }

        /// <summary>
        /// Register given lesson..
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public async Task<RegistrationResult> RegisterAsync(Student student)
        {
            RegistrationResult registrationResult = null;
            //check if lesson exists
            bool isExamExists =  await _examDbContext.Students.HasStudentAsync(student.Number);

            //if exists then error...
            if (isExamExists)
            {
                registrationResult = new RegistrationResult(false)
                {
                    ErrorMessages = new List<string>
                     {
                         "Exam with given lessonCode already exists"
                     }
                };
            }
            else
            {
                try
                {
                    await _examDbContext.Students.AddAsync(student);
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
