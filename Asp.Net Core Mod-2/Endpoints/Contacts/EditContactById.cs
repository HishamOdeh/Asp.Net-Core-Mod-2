using Ardalis.ApiEndpoints;
using Asp.Net_Core_Mod_2.Data;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class EditContactById : EndpointBaseAsync
        .WithRequest<UpdateContactRequst>
        .WithActionResult<Contact>
    {
        // Step 1 : do DI for dbcontex
        private readonly ContactsContext _context;
        public EditContactById (ContactsContext context)
        {
            _context = context;
        }
        //Step 2 :Add HTTP Method and route
        [HttpPut(UpdateContactRequst.RouteTemp)]
        //step 3 :Your Handle method
        public override async Task<ActionResult<Contact>> 
        HandleAsync([FromMultiSource] UpdateContactRequst request, CancellationToken cancellationToken = default)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (contact is null) return NotFound();
            
            contact.LastName = request.UpdatedContact.LastName;
            contact.FirstName = request.UpdatedContact.FirstName;
            contact.PhoneNumber = request.UpdatedContact.PhoneNumber;
            contact.BirthDate = request.UpdatedContact.BirthDate;
            contact.IsActive = request.UpdatedContact.IsActive;
            contact.InActivatedDate = request.UpdatedContact.InActivatedDate;

            await _context.SaveChangesAsync();

            return Ok(contact);
        }
    }
}
