using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Asp.Net_Core_Mod_2.Endpoints.Contacts;
using Asp.Net_Core_Mod_5.Shared;
using FluentAssertions;
using System.Net.Http.Json;

namespace Asp.Net_Core_Mod_2.IntegrationTests
{
    public class RepoDbIntegrationTests : IClassFixture<ContactWebApplicationFactory>
    {
        readonly HttpClient _client;
        public RepoDbIntegrationTests(ContactWebApplicationFactory application)
        {
            _client = application.CreateClient();
        }

        [Fact]
        public async Task GET_AllContacts_retrunsContacts_ByStatsCode()
        {
            var response = await _client.GetAsync(ContactResponseDto.RouteTempGetAll);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Wrong_EndpointRoute_Returns_NotFound_ByContactsList()
        {
            var response = await _client.GetAsync("/api/GetCon6tactByIdbadRoute"); //note the 6 in the route 
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task GET_AllContacts_returnsContacts()
        {
            var response = await _client.GetAsync(ContactResponseDto.RouteTempGetAll);

            var contacts = await response.Content.ReadFromJsonAsync<ContactResponseDto>();
            contacts.Should().NotBeNull();
            contacts.Contacts.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public async Task GET_ContactById_returnsContact_WithValidId_ByStatsCode()
        {
            Guid testId = Guid.Parse("c9895b85-9304-42b7-a5d9-08db6cf9923a");

            var response = await _client.GetAsync(ContactResponseDto.RouteTempGetById.Replace("{id}", testId.ToString()));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task GET_ContactById_returnsContact_WithValidId_ByChechingContact()
        {
            Guid testId = Guid.Parse("c9895b85-9304-42b7-a5d9-08db6cf9923a");
            var response = await _client.GetAsync(ContactResponseDto.RouteTempGetById.Replace("{id}", testId.ToString()));

            var contact = await response.Content.ReadFromJsonAsync<ContactResponseDto.ContactDto>();
            contact.Should().NotBeNull();
            contact.Id.Should().Be(testId);
        }
        [Fact]
        public async Task GET_ContactById_returnsNotFound_WithInvalidId()
        {
            Guid testId = Guid.Parse("c9895b95-9304-42b7-a5d9-08db6cf9923a"); // This ID should not exist in the database.

            var response = await _client.GetAsync(ContactResponseDto.RouteTempGetById.Replace("{id}", testId.ToString()));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task GET_ContactById_InvalidGuidFormat_ReturnsBadRequest()
        {
            var invalidId = "123"; // not a valid Guid
            var response = await _client.GetAsync(ContactResponseDto.RouteTempGetById.Replace("{id}", invalidId));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
