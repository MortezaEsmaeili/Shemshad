using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Shmshad.Presentation.Controllers
{
    [Route("api/schools")]
    [ApiController]
    public class SchoolsController : Controller
    {
        private readonly IServiceManager _service;

        public SchoolsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetSchools")]
        public async Task<IActionResult> GetSchools()
        {
            var schools =
                await _service.SchoolService.GetAllSchoolsAsync(trackChanges: false);
            return Ok(schools);
        }

        [HttpGet("{id:guid}", Name = "SchoolById")]
        public async Task<IActionResult> GetSchool(Guid id) 
        { 
            var school = 
                await _service.SchoolService.GetSchoolAsync(id, trackChanges: false);
            return Ok(school); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateSchool([FromBody] SchoolForCreationDto school)
        {
            if(school == null)
                return BadRequest("SchoolForCreationDto is null");
            var createdSchool = await _service.SchoolService.CreateSchoolAsync(school);
            return CreatedAtRoute("SchoolById", new { id = createdSchool.Id }, createdSchool);
        }

        [HttpGet("collection/({ids})", Name = "SchoolCollection")]
        public async Task<IActionResult> GetSchoolCollection(IEnumerable<Guid> ids)
        {
            var schools = await _service.SchoolService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(schools);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateSchoolCollection([FromBody]
            IEnumerable<SchoolForCreationDto> schoolCollection)
        {
            var result = await _service.SchoolService.CreateSchoolCollectionAsync(schoolCollection);

            return CreatedAtRoute("SchoolCollection", new { result.ids }, result.schools);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSchool(Guid id)
        {
            await _service.SchoolService.DeleteSchoolAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSchool(Guid id, [FromBody] SchoolForUpdateDto school)
        {
            if(school is null)
                return BadRequest("SchoolForUpdateDto object is null!");
            await _service.SchoolService.UpdateSchoolAsync(id,school,trackChanges: true);
            return NoContent();
        }
    }
}
