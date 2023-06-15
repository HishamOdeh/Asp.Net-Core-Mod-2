using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Asp.Net_Core_Mod_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RepoDb;
using RepoDb.Extensions;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class GetContactByIdRepoDb : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<Contact>
    {
        [HttpGet("api/RepoDb/GetContactById/{id}")]

        public override async Task<ActionResult<Contact>> HandleAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            using (var connection = new SqlConnection(GetAllContactResponse.ConnectionString))
            {
                var contacts = await connection.QueryAsync<Contact>(new { Id = id });
                var contact = contacts.FirstOrDefault();
                if (contacts.AsList() == null)
                {
                    return NotFound("Contacts database not found  empty.");
                }
                if (contact == null)
                {
                    return NotFound($"Contact with ID {id} not found.");
                }

                return contact;
            }
        }
    }
}
