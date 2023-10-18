using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teniaco_SecondSenario_Api.Models.Dtos.Person;

namespace Teniaco_SecondSenario_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPerson(GetPersonDto request)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreatePerson(GetPersonDto request)
        {
            return Ok();
        }

    }
}
