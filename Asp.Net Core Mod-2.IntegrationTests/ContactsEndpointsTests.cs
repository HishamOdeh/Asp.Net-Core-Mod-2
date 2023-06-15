using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Asp.Net_Core_Mod_2.Data;
using Asp.Net_Core_Mod_2.Endpoints.Contacts;
using Azure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core_Mod_2.IntegrationTests
{
    public class ContactsEndpointsTests : IClassFixture<ContactWebApplicationFactory>
    {
            readonly HttpClient _client;

    public ContactsEndpointsTests(ContactWebApplicationFactory application)
    {
        _client = application.CreateClient();
        }
        GetContactByIdCommand getRequest = new GetContactByIdCommand();
        DeleteContactCommand deleteRequest = new DeleteContactCommand();

        [Fact]
        public async Task GET_ContactByID_retrieves_contactByID()
        {
            getRequest.Id = Guid.Parse("4255744f-2013-4773-c34f-08db6cea83b5");
            var response = await _client.GetAsync(getRequest.TestRoute);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task GET_ContactByID_ReturnBAdRequestIfNotFound()
        {
            getRequest.Id = Guid.Parse("4245744f-2013-4773-c34f-08db6cea83b5");
            var response = await _client.GetAsync(getRequest.TestRoute);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Wrong_EndpointRoute_Returns_NotFound()
        {
            getRequest.Id = Guid.Parse("4245744f-2013-4773-c34f-08db6cea83b5");
            var response = await _client.GetAsync($"/api/GetCon6tactById?id={getRequest.Id}"); //note the 6 in the route 
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task GET_AllContacts_retrunsContacts()
        {
            var response = await _client.GetAsync("api/GetAllContacts");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Delete_ReturnBAdRequestIfNotFound()
        {
            deleteRequest.Id = Guid.Parse("b9f62411-438e-4ac4-a5d8-08db6cf9923a");
            var response = await _client.DeleteAsync(deleteRequest.TestRoute);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task Delete_ReturnOk_IfFound()
        {
            deleteRequest.Id = Guid.Parse("4255744f-2013-4773-c34f-08db6cea83b5");
            var response = await _client.DeleteAsync(deleteRequest.TestRoute);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Delete_ReturnsSuccessMessage_WhenContactIsDeleted()
        {
            deleteRequest.Id = Guid.Parse("40aa2cd1-1d45-4582-a5da-08db6cf9923a");
            var response = await _client.DeleteAsync(deleteRequest.TestRoute);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Be("Contact Deleted successfully.");
        }
        public async Task Delete_ReturnNOtFound_IfNOtFound()
        {
            // GET_ContactByID_ReturnBAdRequestIfNotFound;
            var response = await _client.DeleteAsync(deleteRequest.TestRoute);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
