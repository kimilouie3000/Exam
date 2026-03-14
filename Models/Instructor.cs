using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        [Required]
        public string EmployeeNo { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int DepartmentId { get; set; }
    }
}
