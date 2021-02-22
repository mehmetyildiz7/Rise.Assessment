using Microsoft.AspNetCore.Mvc;
using Rise.Assessment.Business.Services;
using Rise.Assessment.Common.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Rise.Assessment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var list = (await _personService.GetAllAsync()).Select(x => new {x.Id, x.Name, x.Surname, x.Company}).ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var person = await _personService.FindAsync(id);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody]PersonModel personModel)
        {
            var result = await _personService.UpdateAsync(personModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _personService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]PersonModel model)
        {
            var result = await _personService.CreateAsync(model);
            return Ok(result);
        }

        [HttpPost("{id}/Contacts")]
        public async Task<IActionResult> AddContactInfo([FromBody]ContactInfoModel model,[FromRoute]Guid id)
        {
            var result = await _personService.AddContactInfo(model, id);
            return Ok(result);
        }

        [HttpDelete("{id}/Contacts/{contactId}")]
        public async Task<IActionResult> RemoveContactInfo([FromRoute]Guid id, [FromRoute]Guid contactId)
        {
            var result = await _personService.RemoveContactInfo(id, contactId);
            return Ok(result);
        }
    }
}
