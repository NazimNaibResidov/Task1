using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public Lesson Lesson { get; set; }
        public string LessonCode { get; set; }

        public Student Student { get; set; }
        public int StudentNumber { get; set; }

        [Required]
        [Column(TypeName ="date")]
        public DateTime ExamDate { get; set; }

        [Required]
        public byte Rate { get; set; }
    }
}
