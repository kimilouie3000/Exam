using Microsoft.AspNetCore.Mvc;
using Exam.Data;
using Exam.Models;

namespace Exam.Controllers
{
    [ApiController]
    [Route("api/instructors")]
    public class InstructorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstructorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetInstructors()
        {
            return Ok(_context.Instructors.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetInstructor(int id)
        {
            var instructor = _context.Instructors.Find(id);

            if (instructor == null)
                return NotFound();

            return Ok(instructor);
        }

        [HttpPost]
        public IActionResult CreateInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return Ok(instructor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInstructor(int id, Instructor instructor)
        {
            if (id != instructor.InstructorId)
                return BadRequest();

            _context.Instructors.Update(instructor);
            _context.SaveChanges();

            return Ok(instructor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            var instructor = _context.Instructors.Find(id);

            if (instructor == null)
                return NotFound();

            _context.Instructors.Remove(instructor);
            _context.SaveChanges();

            return Ok();
        }
    }
}
