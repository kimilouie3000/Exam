using Microsoft.AspNetCore.Mvc;
using Exam.Data;
using Exam.Models;

namespace Exam.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(_context.Courses.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Courses.Add(course);
            _context.SaveChanges();

            return Ok(course);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            if (id != course.CourseId)
                return BadRequest();

            _context.Courses.Update(course);
            _context.SaveChanges();

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return Ok();
        }
    }
}

