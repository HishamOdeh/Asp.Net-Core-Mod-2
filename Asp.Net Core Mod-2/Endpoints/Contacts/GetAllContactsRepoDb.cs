using System;
using Ardalis.ApiEndpoints;
using Asp.Net_Core_Mod_2.Data;
using Asp.Net_Core_Mod_5.Shared;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Core;
using RepoDb;
using RepoDb.Extensions;
//using Asp.Net_Core_Mod_5.Shared;
namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class GetAllContactsRepoDb : EndpointBaseAsync
      .WithoutRequest
      .WithActionResult<ContactResponseDto>
    {
        private readonly IConfiguration _configuration;
        public GetAllContactsRepoDb(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ContactResponseDto.RouteTempGetAll)]
        public override async Task<ActionResult<ContactResponseDto>> HandleAsync(CancellationToken cancellationToken = default)
        {
            using var connection = await new SqlConnection(_configuration.GetConnectionString("DefaultConnection")).EnsureOpenAsync();

            var contacts = await connection.ExecuteQueryAsync<ContactResponseDto.ContactDto>(CreateSql());
            if (contacts == null || !contacts.Any())
            {
                return NotFound("Contacts database not found or empty.");
            }

            return Ok(ContactResponseDto.Response(contacts));

            string CreateSql()
            {
                return @"SELECT [Id]
                        ,[LastName]
                        ,[FirstName]
                        ,[PhoneNumber]
                        ,[BirthDate]
                        ,[IsActive]
                        ,[InActivatedDate]
                    FROM [ModTwo].[dbo].[Contacts]";
            }
        }
    }

}




