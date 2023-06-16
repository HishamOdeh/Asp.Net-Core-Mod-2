using Asp.Net_Core_Mod_2.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace Asp.Net_Core_Mod_2.IntegrationTests
{
    namespace Asp.Net_Core_Mod_2.IntegrationTests
    {
        public class ContactsControllerTests : IClassFixture<ContactWebApplicationFactory>
        {
            readonly HttpClient _client;

            public ContactsControllerTests(ContactWebApplicationFactory application)
            {
                _client = application.CreateClient();
            }

            [Fact]
            public async Task GET_retrieves_contact()
            {
                var response = await _client.GetAsync("/api/Contacts/GetAllContacts");
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            [Fact]
            public async Task GET_retrieves_contact_by_id()
            {
                // Arrange
                var expectedContactId = new Guid("c9895b85-9304-42b7-a5d9-08db6cf9923a");

                // Act
                var response = await _client.GetAsync($"/api/Contacts/GetContactById?id={expectedContactId}");

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);
              
            }
            /*
            [Fact]
            public async Task DELETE_removes_contact_by_id()
            {
                // Arrange
                var contactIdToDelete = new Guid("917ddbba-af33-42f9-8f46-08db6ce4234e");

                // Act
                var response = await _client.DeleteAsync($"/api/Contacts/DeleteContactById?id={contactIdToDelete}");

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
            */


        }

    }
}