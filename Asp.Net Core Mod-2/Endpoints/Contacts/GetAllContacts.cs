using Ardalis.ApiEndpoints;
using Asp.Net_Core_Mod_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class GetAllContacts : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<List<Contact>>
    {
        private readonly ContactsContext _context;
        public GetAllContacts(ContactsContext context)
        {
            _context = context;  
        }

        [HttpGet("api/GetAllContacts")]
        public override async Task<ActionResult<List<Contact>>> 
            HandleAsync(CancellationToken cancellationToken = default)
        {
            if (_context.Contacts == null)
            {
                return NotFound("Contacts database not found  empty.");
            }

            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);        
        }
    }
}
