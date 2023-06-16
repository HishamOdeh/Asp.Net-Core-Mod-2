using Ardalis.ApiEndpoints;
using Asp.Net_Core_Mod_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class InActivate : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<Contact>
    {
        // Step 1 : do DI for dbcontex
        private readonly ContactsContext _context;
        public InActivate(ContactsContext context)
        {
            _context = context;
        }
        [HttpPut(InActivateResponse.RouteTemp)]

        public override async Task<ActionResult<Contact>> HandleAsync([FromQuery]Guid id, CancellationToken cancellationToken = default)
        {
            //get the contact
            var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (contact is null) return NotFound();

            // using the InActive method in the contact model
            contact.InActivate();
            //contact.IsActive = false;
            //contact.InActivatedDate = DateTime.UtcNow;
            //save changes
            await _context.SaveChangesAsync();

            //retrun contact
            return Ok(contact);
        }
    }
}
