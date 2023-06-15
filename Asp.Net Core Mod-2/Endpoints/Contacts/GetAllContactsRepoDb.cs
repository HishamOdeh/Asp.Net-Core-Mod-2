using System;
using Ardalis.ApiEndpoints;
using Asp.Net_Core_Mod_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepoDb;
using RepoDb.Extensions;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class GetAllContactsRepoDb : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<List<Contact>>
    {
        [HttpGet(GetAllContactResponse.RouteTemp)]

        public override async Task<ActionResult<List<Contact>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            using (var connection = new SqlConnection(GetAllContactResponse.ConnectionString))
            {
                var contacts = await connection.QueryAllAsync<Contact>();
                if (contacts.AsList() == null)
                {
                    return NotFound("Contacts database not found  empty.");
                }
                return contacts.AsList();

            }
        }
    }
}




    /*
    public class GetAllContactsRepoDb : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<List<Contact>>
    {
        [HttpGet("api/RepoDb/GetAllContacts")]

        public override async Task<ActionResult<List<Contact>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            using (var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=ModTwo;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                var contacts = await connection.QueryAllAsync<Contact>();
                if (contacts.AsList() == null)
                {
                    return NotFound("Contacts database not found  empty.");
                }
                return contacts.AsList();

            }
            throw new NotImplementedException();
        }
    }
    */

