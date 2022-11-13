using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Shemshad.Presentation.Controllers
{
    [Route("api/schools/{schoolId}/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IServiceManager _service;
        public StudentController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsForSchool(Guid schoolID)
        {
            var students =
                await _service.StudentService.GetStudentsAsync(schoolID, trackChanges: false);
            return Ok(students);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStudentForSchool(Guid schoolId, Guid id)
        {
            var student = await _service.StudentService.GetStudentAsync(schoolId, id, trackChanges: false);
            return Ok(student);
        }
    }
}
