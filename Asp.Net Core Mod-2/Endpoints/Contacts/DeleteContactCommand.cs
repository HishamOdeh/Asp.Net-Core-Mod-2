using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class DeleteContactCommand
    {
        public const string RouteTemp = "api/DeleteContactById";

        public Guid Id { get; set; }
        public string TestRoute
        {
            get
            {
                return "api/DeleteContactById?id=" + Id.ToString();
            }
        }
    }
}
