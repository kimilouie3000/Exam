using Microsoft.AspNetCore.Mvc;
using Exam.Data;
using Exam.Models;

namespace Exam.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEnrollments()
        {
            return Ok(_context.Enrollments.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetEnrollment(int id)
        {
            var enrollment = _context.Enrollments.Find(id);

            if (enrollment == null)
                return NotFound();

            return Ok(enrollment);
        }

        [HttpGet("byStudent/{studentId}")]
        public IActionResult GetByStudent(int studentId)
        {
            var enrollments = _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .ToList();

            return Ok(enrollments);
        }

        [HttpPost]
        public IActionResult CreateEnrollment(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            return Ok(enrollment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(int id, Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
                return BadRequest();

            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();

            return Ok(enrollment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            var enrollment = _context.Enrollments.Find(id);

            if (enrollment == null)
                return NotFound();

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();

            return Ok();
        }
    }
}

