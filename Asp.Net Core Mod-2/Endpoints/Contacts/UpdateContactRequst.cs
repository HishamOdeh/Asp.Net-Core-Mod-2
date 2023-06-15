using Asp.Net_Core_Mod_2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class UpdateContactRequst
    {

        [FromQuery] public Guid Id { get; set; }

        [FromBody] public Contact UpdatedContact { get; set; } = default!;
        public const string RouteTemp = "api/UpdateContactById";
    }
}
