using RepoDb.Attributes;
using System;

namespace Asp.Net_Core_Mod_2.Data
{
    [Map("Contacts")] // Maps this class to the "Contacts" table in the database
    public class Contact
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InActivatedDate { get; set; }

        public void InActivate()
        {
            IsActive = false;
            InActivatedDate = DateTime.UtcNow;
        }
    }
}
