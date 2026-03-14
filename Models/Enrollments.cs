using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [Required]
        public string Semester { get; set; }

        [Range(1.00, 5.00)]
        public double Grade { get; set; }
    }
}

