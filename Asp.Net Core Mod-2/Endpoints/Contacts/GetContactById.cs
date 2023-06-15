using Ardalis.ApiEndpoints;
using Asp.Net_Core_Mod_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class GetContactById : EndpointBaseAsync
        .WithRequest<GetContactByIdCommand>
        .WithActionResult<Contact>

    {
        private readonly ContactsContext _context;
        public GetContactById(ContactsContext context)
        {
            _context = context;
        }

        [HttpGet(GetContactByIdCommand.RouteTemp)]

        public override async Task<ActionResult<Contact>>
            HandleAsync([FromMultiSource] GetContactByIdCommand request, CancellationToken cancellationToken = default)
        {
            if (_context.Contacts == null)
            {
                return NotFound("Contacts database not found or empty.");
            }
            var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (contact == null)
            {
                return NotFound($"Contact with ID {request.Id} does not exist.");
            }

            return contact;
        }
    }
}
