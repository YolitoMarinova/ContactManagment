using ContactManagment.Application.Contact.Commands.CreateContactCommand;
using ContactManagment.Application.Contact.Commands.DeleteContactCommand;
using ContactManagment.Application.Contact.Commands.UpdateContactCommand;
using ContactManagment.Application.Contact.Queries.GetAllContactQuery;
using ContactManagment.Application.Contact.Queries.GetByIdContactQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var contact = await _mediator.Send(new GetByIdContactQuery(id));

            if(contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _mediator.Send(new GetAllContactQuery());
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactCommand command)
        {
            var contactId = await _mediator.Send(command);

            if(contactId == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(new { id = contactId });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContactCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteContactCommand(id));
            return NoContent();
        }
    }
}
