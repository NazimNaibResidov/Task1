using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Core.Services.ServiceModels
{
    public class RegistrationResult
    {
        public RegistrationResult(bool isSuccess)
        {
            IsSucceeded = isSuccess;
        }
        public  bool IsSucceeded { get; private set; }
        public IEnumerable<string> ErrorMessages { get; internal set; }
    }
}
