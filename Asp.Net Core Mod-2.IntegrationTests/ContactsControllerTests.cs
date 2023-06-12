using FluentAssertions;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Asp.Net_Core_Mod_2.IntegrationTests
{
    public class ContactsControllerTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        readonly HttpClient _client;


        public ContactsControllerTests(WebApplicationFactory<Api.Startup> application)
        {
            _client = application.CreateClient();

        }

        [Fact]
        public async Task GET_retrieves_contact()
        {
            var response = await _client.GetAsync("/GetAllContacts");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
       
    }
}