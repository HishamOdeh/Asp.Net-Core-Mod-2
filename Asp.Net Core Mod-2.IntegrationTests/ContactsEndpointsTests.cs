﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Asp.Net_Core_Mod_2.Data;
using Asp.Net_Core_Mod_2.Endpoints.Contacts;
using Asp.Net_Core_Mod_5.Shared;
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
        InActivateResponse Activate = new InActivateResponse();
        [Fact]
        public async Task GET_ContactByID_retrieves_contactByID()
        {
            getRequest.Id = Guid.Parse("c9895b85-9304-42b7-a5d9-08db6cf9923a");
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
        public async Task Delete_ReturnBadRequestIfNotFound()
        {
            deleteRequest.Id = Guid.Parse("b9f62411-438e-4ac4-a5d8-08db6cf9923a");
            var response = await _client.DeleteAsync(deleteRequest.TestRoute);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        //InActiveContact tests

        [Fact]
        public async Task PUT_InActivateContact_ReturnsOK_ForValidID()
        {
            Guid testId = Guid.Parse("c9895b85-9304-42b7-a5d9-08db6cf9923a");
            var response = await _client.PutAsync(Activate.TestRoute.Replace("{id}", testId.ToString()), null);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PUT_InActivateContact_SetsIsActiveToFalse()
        {
            Guid testId = Guid.Parse("c9895b85-9304-42b7-a5d9-08db6cf9923a");
            var response = await _client.PutAsync(Activate.TestRoute.Replace("{id}", testId.ToString()), null);

            var responseContact = await response.Content.ReadFromJsonAsync<Contact>();
            responseContact.IsActive.Should().BeFalse();
        }

        [Fact]
        public async Task PUT_InActivateContact_SetsRecentInActivatedDate()
        {
            Guid testId = Guid.Parse("c9895b85-9304-42b7-a5d9-08db6cf9923a");
            var response = await _client.PutAsync(Activate.TestRoute.Replace("{id}", testId.ToString()), null);
            var responseContact = await response.Content.ReadFromJsonAsync<Contact>();
            responseContact.InActivatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        }

        [Fact]
        public async Task PUT_InActivateContact_ReturnsNotFound_ForInvalidID()
        {
            Guid testId = Guid.NewGuid(); // asume the default value of a Guid won't be in your db
            var response = await _client.PutAsync(Activate.TestRoute.Replace("{id}", testId.ToString()), null);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        //is it a good idea to add a DbConext instance and create a contact
        //and add it to the db and then try to delete it and run the tsts onnthat newly generated contacts?

        // When you run these tessts will effect thhe data base, and when they pass they will
        // fail the next imte if you dont cahnge the id to an existsing id

        /*
        [Fact]
        public async Task Delete_ReturnOk_IfFound()
        {
            deleteRequest.Id = Guid.Parse("c9895b85-9304-42b7-a5d9-08db6cf9923a");
            var response = await _client.DeleteAsync(deleteRequest.TestRoute);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Delete_ReturnsSuccessMessage_WhenContactIsDeleted()
        {
            deleteRequest.Id = Guid.Parse("c9895b85-9304-42b7-a5d9-08db6cf9923a");
            var response = await _client.DeleteAsync(deleteRequest.TestRoute);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Be("Contact Deleted successfully.");
        }
        */
    }
}
