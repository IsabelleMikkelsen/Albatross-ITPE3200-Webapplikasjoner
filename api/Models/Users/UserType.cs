using System;
using System.ComponentModel.DataAnnotations;

namespace Albatross.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }

        public string Name { get; set; } = string.Empty; //Add default value


        public ICollection<User> Users { get; set; } = new List<User>(); //Add default value
    }
}