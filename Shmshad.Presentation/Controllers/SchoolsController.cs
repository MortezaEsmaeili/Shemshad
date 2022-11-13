using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Shmshad.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolsController : Controller
    {
        private readonly IServiceManager _service;

        public SchoolsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var schools =
                    await _service.SchoolService.GetAllSchoolsAsync(trackChanges: false);
                return Ok(schools);
            } 
            catch
            { 
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
