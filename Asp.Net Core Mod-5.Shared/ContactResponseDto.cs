using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net_Core_Mod_5.Shared
{
    internal class ContactResponseDto
    {
        public Guid Id { get; set; }
        public string RouteTemp = "api/RepoDb/GetAllContacts";
    }
}
