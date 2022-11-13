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
    }
}
