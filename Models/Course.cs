using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1, 6)]
        public int Units { get; set; }
    }
}

