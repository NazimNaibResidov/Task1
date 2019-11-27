using System.ComponentModel.DataAnnotations;

namespace ExamApp.Models
{
    public class Lesson
    {

        [Key]
        [Required]
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        public string Code { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1, 11)]
        public byte LessonClass { get; set; }

        [Required]
        [MaxLength(20)]
        public string TeacherName { get; set; }

        [Required]
        [MaxLength(20)]
        public string TeacherSurname { get; set; }

    }
}
