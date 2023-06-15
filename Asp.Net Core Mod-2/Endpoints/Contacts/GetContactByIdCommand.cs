using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class GetContactByIdCommand
    {
        public const string RouteTemp = "api/GetContactById/{id}";
        [FromRoute]
        public Guid Id { get; set; }

        public string TestRoute
        {
            get
            {
                return "api/GetContactById/" + Id.ToString();
            }
        }
    }
}
