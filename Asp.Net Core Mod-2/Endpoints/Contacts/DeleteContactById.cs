using Ardalis.ApiEndpoints;
using Asp.Net_Core_Mod_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class DeleteContactById : EndpointBaseAsync
        .WithRequest <Guid>
        .WithActionResult<DeleteContactCommand>
    {
        private readonly ContactsContext _context;

        // Constructor accepting a ContactsContext instance (injected by the DI system).
        public DeleteContactById(ContactsContext context)
        {
            _context = context;
        }
        [HttpDelete(DeleteContactCommand.RouteTemp)]
        public override async Task<ActionResult<DeleteContactCommand>>
            HandleAsync([FromQuery] Guid id, CancellationToken cancellationToken = default)
        {
            if (_context.Contacts == null)
            {
                return NotFound("Entity set 'ContactsContext.Contacts'  is null.");
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (contact is null)
            {
                return NotFound($"Contact with ID {id} does not exist.");
            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            string message = "Contact Deleted successfully.";
            return Ok(message);
        }
    }
}
