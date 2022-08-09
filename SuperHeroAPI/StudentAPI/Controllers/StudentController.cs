using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;
      
        public StudentController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return BadRequest("Student not Found.");
            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student request)
        {
            var dbstudent = await _context.Students.FindAsync(request.Id);
            if (dbstudent == null) return BadRequest("Student not Found.");

            dbstudent.FirstName = request.FirstName;
            dbstudent.LastName = request.LastName;
            dbstudent.MatricNo = request.MatricNo;
            dbstudent.Level = request.Level;
            dbstudent.Department = request.Department;
            dbstudent.Program = request.Program;
            if (request.Program != null)
            {
                dbstudent.IsActive = request.IsActive;
            }


            await _context.SaveChangesAsync();


            return Ok(await _context.Students.ToListAsync());
        }

       

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {

            var dbstudent = await _context.Students.FindAsync(id);
            if (dbstudent == null) return BadRequest("Student not Found.");

            _context.Students.Remove(dbstudent);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
    }
}
