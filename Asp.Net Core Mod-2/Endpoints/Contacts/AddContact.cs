using Ardalis.ApiEndpoints;
using Asp.Net_Core_Mod_2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class AddContact : EndpointBaseAsync
        .WithRequest<Contact>
        .WithActionResult<AddContactCommand>
    {
        private readonly ContactsContext _context;
        public AddContact(ContactsContext context)
        {
            _context = context;
        }
        [HttpPost(AddContactCommand.RouteTemp)]
        public override async Task <ActionResult<AddContactCommand>>
            HandleAsync(Contact request, CancellationToken cancellationToken = default)
        {
            
            // Add the Contact to the Contacts set.
            _context.Contacts.Add(request);
            // Save changes asynchronously.
            await _context.SaveChangesAsync();

            return Ok();
            //return CreatedAtAction(nameof(AddContact), new { id = request.Id }, message);
        }
    }
}
