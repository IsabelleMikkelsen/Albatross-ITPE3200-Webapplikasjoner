using System;

namespace Albatross.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        
        public User User { get; set; } = null!; //Null-forgiving operator
    }
}