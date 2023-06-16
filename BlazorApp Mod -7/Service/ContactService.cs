using Asp.Net_Core_Mod_5.Shared;

namespace BlazorApp_Mod__7.Service
{
    public class ContactService : IContactService
    {
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

    }
}
