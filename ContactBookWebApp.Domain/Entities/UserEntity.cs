

using Microsoft.AspNetCore.Identity;

namespace ContactBookWebApp.Domain.Entities
{
    public class UserEntity : IdentityUser
    {
        public string PhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
       

       // public ICollection<Contact> Contacts { get; set; }

    }
}
