using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teniaco_SecondSenario_Api.Models.Dtos.Person;
using Teniaco_SecondSenario_Api.Models.Entities.Person;
using Teniaco_SecondSenario_Api.Repositories.Interfaces;

namespace Teniaco_SecondSenario_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet(Name = "GetPerson")]
        public async  Task<IActionResult> GetPerson([FromQuery]GetPersonDto request)
        {
            return Ok(await _personRepository.GetPerson(request.Id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromForm] CreatePersonDto request)
        {
            return Ok( await _personRepository.CreatePerson(request));
        }

        [HttpGet(Name = "GetAllPersons")]
        public async Task<IActionResult> GetAllPersons()
        {
            return Ok(await _personRepository.GetPersons());
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> EditPerson([FromRoute] long id,[FromForm] UpdatePersonDto request)
        {
            return Ok(await _personRepository.UpdatePerson(id,request));
        }
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeletePerson(long id)
        {
            return Ok(await _personRepository.DeletePerson(id));
        }
    }
}
