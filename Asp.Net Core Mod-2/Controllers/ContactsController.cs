using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asp.Net_Core_Mod_2.Data;


namespace Asp.Net_Core_Mod_2.Controllers
{
    // Specifies URL pattern for this controller.
    [Route("api/[controller]")]
    // Indicates this class uses API behavior conventions.
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // Field to store the ContactsContext instance provided by dependency injection.
        private readonly ContactsContext _context;

        // Constructor accepting a ContactsContext instance (injected by the DI system).
        public ContactsController(ContactsContext context)
        {
            _context = context;  // Assign the injected instance to the private field.
        }

        // GET: api/Contacts
        [HttpGet("GetAllContacts")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            // If Contacts set in the context is null, return NotFound (HTTP 404)
            if (_context.Contacts == null)
          {
                return NotFound("Contacts database not found.");
            }
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/Contacts/GetContactById
        [HttpGet("GetContactById")] // figure put how to add the {id} as query params
        public async Task<ActionResult<Contact>> GetContact( [FromQuery]Guid id)
        {
            // If Contacts set in the context is null, return NotFound (HTTP 404)
            if (_context.Contacts == null)
            {
                return NotFound("Contacts database not found.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            
            // If the Contact does not exist, return NotFound (HTTP 404).

            if (contact == null)
            {
                return NotFound($"Contact with ID {id} does not exist.");
            }

            return contact;
        }

        // PUT: api/Contacts/UpdateContactById
        [HttpPut("UpdateContactById")]
        public async Task<IActionResult> PutContact( [FromQuery]Guid id, Contact contact)
        {
            // If the ID does not match the Contact's ID, return BadRequest (HTTP 400).
            if (id != contact.Id) //This makes sure that the contactin the body has the same ID as the ID in the path
            {
                return BadRequest("Mismatch between provided ID and contact's ID.");
            }

            _context.Entry(contact).State = EntityState.Modified; //This updates the contacts info

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound($"Contact with ID {id} does not exist.");
                }
                else
                {
                    throw;
                }
            }
            // Add a descriptive message indicating successful update and return the updated contact.
            var message = $"Contact with ID {id} has been updated successfully.";
            return Ok(new { Message = message, Contact = contact });
        }

        // POST: api/Contacts
        [HttpPost("AddContact")]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
          if (_context.Contacts == null)
          {
              return Problem("Entity set 'ContactsContext.Contacts'  is null.");
          }
            // Add the Contact to the Contacts set.
            _context.Contacts.Add(contact);
            // Save changes asynchronously.
            await _context.SaveChangesAsync();

            var message = "Contact created successfully.";

            // Return a response indicating that the contact was successfully created, along with the custom message. returns a 201 created request
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, new { Message = message, Contact = contact });
        }

        // DELETE: api/Contacts/5
        [HttpDelete("DeleteContactById")]
        public async Task<IActionResult> DeleteContact( [FromQuery] Guid id)
        {
            if (_context.Contacts == null)
            {
                return NotFound("Contacts database not found.");
            }
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound($"Contact with ID {id} does not exist.");
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

           // return Ok("Contact deleted successfully.");
            return NoContent();
        }
        // Checks if a Contact with the given ID exists in the Contacts set.
        private bool ContactExists(Guid id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
