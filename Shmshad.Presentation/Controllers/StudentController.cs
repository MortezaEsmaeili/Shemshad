using CompanyEmployees.Presentation.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

        [HttpGet("{id:guid}", Name = "GetStudentsForSchool")]
        public async Task<IActionResult> GetStudentForSchool(Guid schoolId, Guid id)
        {
            var student = await _service.StudentService.GetStudentAsync(schoolId, id, trackChanges: false);
            return Ok(student);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateStudentForSchool(Guid schoolId, [FromBody] StudentForCreationDto student)
        {
            if (student == null)
                return BadRequest("StudentForCreation is null!");

            var studentToReturn = await _service.StudentService.CreateStudentForSchoolAsync(schoolId,student,trackChanges: false);
            return CreatedAtRoute("GetStudentsForSchool", new { schoolId, id = studentToReturn.Id }, studentToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudentForSchool(Guid schoolId, Guid id)
        {
            await _service.StudentService.DeleteStudentForSchoolAsync(schoolId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateStudentForSchool(Guid schoolID, Guid id,
            [FromBody] StudentForUpdateDto student)
        {
            if(student is null)
                return BadRequest("StudentForUpdateDto object is null!");
            await _service.StudentService.UpdateStudentForSchoolAsync(schoolID,
                id, student, false, true);
            return NoContent();
        }
    }
}
