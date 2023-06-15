using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Asp.Net_Core_Mod_2.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }


        public DbSet<Contact> Contacts { get; set; } = null!;

    }
}
