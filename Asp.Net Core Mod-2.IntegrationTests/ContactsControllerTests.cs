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
                var expectedContactId = new Guid("9840b20d-94c9-4b97-06d7-08db6922af52");

                // Act
                var response = await _client.GetAsync($"/api/Contacts/GetContactById?id={expectedContactId}");

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);
              
            }
            [Fact]
            public async Task DELETE_removes_contact_by_id()
            {
                // Arrange
                var contactIdToDelete = new Guid("9840b20d-94c9-4b97-06d7-08db6922af52");

                // Act
                var response = await _client.DeleteAsync($"/api/Contacts/DeleteContactById?id={contactIdToDelete}");

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }


        }

    }
}