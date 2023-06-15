using Asp.Net_Core_Mod_2.Data;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class GetAllContactResponse
    {
        public const string RouteTemp = "api/RepoDb/GetAllContacts";
     

        public const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ModTwo;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
