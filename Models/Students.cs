using System;
using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentNo { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}