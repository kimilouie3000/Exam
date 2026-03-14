using Microsoft.AspNetCore.Mvc;
using Exam.Data;
using Exam.Models;

namespace Exam.Controllers
{
    [ApiController]
    [Route("api/sections")]
    public class SectionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSections()
        {
            return Ok(_context.Sections.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetSection(int id)
        {
            var section = _context.Sections.Find(id);

            if (section == null)
                return NotFound();

            return Ok(section);
        }

        [HttpPost]
        public IActionResult CreateSection(Section section)
        {
            _context.Sections.Add(section);
            _context.SaveChanges();
            return Ok(section);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSection(int id, Section section)
        {
            if (id != section.SectionId)
                return BadRequest();

            _context.Sections.Update(section);
            _context.SaveChanges();

            return Ok(section);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSection(int id)
        {
            var section = _context.Sections.Find(id);

            if (section == null)
                return NotFound();

            _context.Sections.Remove(section);
            _context.SaveChanges();

            return Ok();
        }
    }
}

