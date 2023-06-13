using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace Asp.Net_Core_Mod_2.IntegrationTests
{
    namespace Asp.Net_Core_Mod_2.IntegrationTests
    {
        public class ContactsControllerTests : IClassFixture<WebApplicationFactory<Program>>
        {
            readonly HttpClient _client;


            public ContactsControllerTests(WebApplicationFactory<Program> application)
            {
                _client = application.CreateClient();

            }

            [Fact]
            public async Task GET_retrieves_contact()
            {
                var response = await _client.GetAsync("/api/Contacts/GetAllContacts");
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }

        }

    }
}