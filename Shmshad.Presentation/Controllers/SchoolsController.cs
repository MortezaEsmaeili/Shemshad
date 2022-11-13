using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
            return Ok(school); }
    }
}
