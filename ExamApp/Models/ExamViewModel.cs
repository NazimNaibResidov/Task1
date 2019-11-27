using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class ExamViewModel
    {
        public IEnumerable<string> LessonCodes { get; set; }
        public IEnumerable<int> StudentNumbers { get; set; }
        public DateTime ExamDate { get; set; }
        public byte Rate { get; set; }
    }
}
