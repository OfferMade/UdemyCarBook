using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactQueryHandler getContactQueryHandler;
        private readonly GetContactByIdQueryHandler getContactByIdQueryHandler;
        private readonly RemoveContactCommandHandler removeContactCommandHandler;
        private readonly UpdateContactCommandHandler updateContactCommandHandler;
        private readonly CreateContactCommandHandler createContactCommandHandler;

        public ContactsController(GetContactQueryHandler getContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, CreateContactCommandHandler createContactCommandHandler)
        {
            this.getContactQueryHandler = getContactQueryHandler;
            this.getContactByIdQueryHandler = getContactByIdQueryHandler;
            this.removeContactCommandHandler = removeContactCommandHandler;
            this.updateContactCommandHandler = updateContactCommandHandler;
            this.createContactCommandHandler = createContactCommandHandler;
        }

        [HttpGet("ContactList")]
        public async Task<IActionResult> ContactList()
        {
            var values = await getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await getContactByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.ContactQueries.GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await createContactCommandHandler.Handle(command);
            return Ok("Contact oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await updateContactCommandHandler.Handle(command);
            return Ok("Contact güncellendi");
        }

        [HttpDelete("RemoveContact")]
        public async Task<IActionResult> RemoveContact(RemoveContactCommand command)
        {
            await removeContactCommandHandler.Handle(command);
            return Ok("Contact silindi");
        }
    }
}
