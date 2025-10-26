/*using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Albatross.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreatedAt { get; set;} = DateTime.Now;

        public ICollection<Module> Modules { get; set; } = new List<Module>();
        /*public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<Admin> Admins { get; set; } = new List<Admin>(); */
    }
}*/