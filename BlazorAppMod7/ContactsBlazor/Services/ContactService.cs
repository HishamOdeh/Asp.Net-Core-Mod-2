using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using Asp.Net_Core_Mod_2.Data;
using Asp.Net_Core_Mod_2.Endpoints.Contacts;
using Asp.Net_Core_Mod_5.Shared;

namespace BlazorAppMod7.ContactsBlazor.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ContactResponseDto.ContactDto>> GetAll()
        {
           return await _httpClient.GetFromJsonAsync<IEnumerable<ContactResponseDto.ContactDto>>(ContactResponseDto.RouteTempGetAll);
        }
        public async Task<ContactResponseDto.ContactDto> GetContactById(Guid contactId)
        {
            return await JsonSerializer.DeserializeAsync<ContactResponseDto.ContactDto>
                (await _httpClient.GetStreamAsync(ContactResponseDto.RouteTempGetById.Replace("{id}", contactId.ToString())), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task  AddContact(ContactResponseDto.ContactDto contact)
        {
            var response = await _httpClient.PostAsJsonAsync<ContactResponseDto.ContactDto>(AddContactCommand.RouteTemp, contact);
            response.EnsureSuccessStatusCode();

       //     return await response.Content.ReadFromJsonAsync<ContactResponseDto.ContactDto>(); 

        }
        public async Task<ContactResponseDto.ContactDto> UpdateContact(Guid id, ContactResponseDto.ContactDto contact)
        {
            // replace with your actual route
            var route = UpdateContactRequst.RouteTemp + "?id=" + id.ToString();
            var response = await _httpClient.PutAsJsonAsync<ContactResponseDto.ContactDto>(route, contact);

            // optionally check for success
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ContactResponseDto.ContactDto>();
        }

        public async Task DeleteContact(Guid contactId)
        {
            var response = await _httpClient.DeleteAsync(DeleteContactCommand.RouteTemp + "?id=" + contactId.ToString());
            
            response.EnsureSuccessStatusCode();
        }
    }
}

/*
 *                 var response = await _httpClient.GetStringAsync("api/RepoDb/GetContactById/c9895b85-9304-42b7-a5d9-08db6cf9923a");
                Console.WriteLine(response); // log the raw response
                return JsonSerializer.Deserialize<List<ContactResponseDto.ContactDto>>(response);

   //  public async Task<IEnumerable<ContactResponseDto.ContactDto>> GetAll()
        //  {
        //      return await _httpClient.GetFromJsonAsync < List<ContactResponseDto.ContactDto>>(ContactResponseDto.RouteTempGetAll);
        // return await JsonSerializer.DeserializeAsync<IEnumerable<ContactResponseDto.ContactDto>>
        //     (await _httpClient.GetStreamAsync($"api/RepoDb/GetAllContacts"), new JsonSerializerOptions());

        //      }
public Task<List<ContactResponseDto.ContactDto>> GetAll()
{
    var contacts = new List<ContactResponseDto.ContactDto>
{
new ContactResponseDto.ContactDto
(
    Guid.NewGuid(),
    "Doe",
    "John",
    "123-456-7890",
    new DateTime(1990, 1, 1),
    true,
    null
),
new ContactResponseDto.ContactDto
(
    Guid.NewGuid(),
    "Brown",
    "Bob",
    "111-222-3333",
    new DateTime(1980, 10, 10),
    true,
    null
),
new ContactResponseDto.ContactDto
(
    Guid.NewGuid(),
    "Taylor",
    "Alice",
    "444-555-6666",
    new DateTime(1995, 2, 2),
    false,
    new DateTime(2023, 5, 1)
)
};

    return Task.FromResult(contacts);
}
*/
