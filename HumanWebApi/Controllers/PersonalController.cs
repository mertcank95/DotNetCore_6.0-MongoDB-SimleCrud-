using HumanWebApi.Entities.Models;
using HumanWebApi.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {

        private readonly IRepositoryBase _repository;

        public PersonalController(IRepositoryBase repository)
        {
            _repository = repository;
        }


        [HttpPost]
        public async Task<IActionResult> CreatePersonal([FromBody] PersonalInformation newPersonal)
        {
            await _repository.CreateNewPersonalAsync(newPersonal);
            return Ok(newPersonal);
        }

        [HttpGet]
        public async Task<List<PersonalInformation>> GetPersonal()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var personal = await _repository.GetByIdAsync(id);
            if (personal is null)
                return NotFound();

            return Ok(personal);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PersonalInformation updatePersonal)
        {
            var personal = await _repository.GetByIdAsync(updatePersonal.Id);
            if (personal is null)
            {
                return NotFound();
            }

            await _repository.UpdatePersonalAsync(updatePersonal);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var personal = await _repository.GetByIdAsync(id);
            if (personal is null)
                return NotFound();
            

            await _repository.DeletePersonalAsync(id);
            return NoContent();
        }

    }
}
