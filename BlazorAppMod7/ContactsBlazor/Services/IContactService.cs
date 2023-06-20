using Asp.Net_Core_Mod_5.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAppMod7.ContactsBlazor.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactResponseDto.ContactDto>> GetAll();
        Task<ContactResponseDto.ContactDto> GetContactById(Guid contactId);
        Task<ContactResponseDto.ContactDto> AddContact(ContactResponseDto.ContactDto contact);
        Task UpdateContact(ContactResponseDto.ContactDto contact);
        Task DeleteContact(Guid contactId);
    }
}