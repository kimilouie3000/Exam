using Microsoft.AspNetCore.Mvc;
using Exam.Data;
using Exam.Models;

namespace Exam.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_context.Departments.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return Ok(department);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, Department department)
        {
            if (id != department.DepartmentId)
                return BadRequest();

            _context.Departments.Update(department);
            _context.SaveChanges();

            return Ok(department);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return Ok();
        }
    }
}

