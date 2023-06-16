using Asp.Net_Core_Mod_5.Shared;

namespace BlazorApp_Mod__7.Service
{
    public interface IContactService
    {
        Task<List<ContactResponseDto.ContactDto>> GetAll();

    }
}
