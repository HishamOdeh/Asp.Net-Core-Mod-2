using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_Mod_2.Endpoints.Contacts
{
    public class UpdateContactCommandById
    {
        [Required]
        [FromRoute]
        public Guid Id { get; set; }

        [FromBody]
        public UpdateDetails Details { get; set; } = null!;

        public class UpdateDetails
        {
            [Required]
            public string LastName { get; set; } = null!;
            [Required]
            public string FirstName { get; set; } = null!;
            [Required]
            public string PhoneNumber { get; set; } = null!;
            public DateTime BirthDate { get; set; }
            public DateTime ? InActivatedDate { get; set;}
            public bool IsActivate { get; set; }

        }

    }
}