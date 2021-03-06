﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApp.Core.Services.ServiceModels;
using ExamApp.Models;

namespace ExamApp.Core.Services.Contracts
{
    public interface ILessonService
    {
        Task<RegistrationResult> RegisterAsync(Lesson lesson);
    }
}
