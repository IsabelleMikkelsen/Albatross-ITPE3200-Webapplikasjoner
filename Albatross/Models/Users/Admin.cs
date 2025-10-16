using System;
namespace Albatross.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        
        public User User { get; set; }
    }
}