using System;
namespace Albatross.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public int ModuleLevel { get; set; }
        public string ModuleName { get; set; } //Eks. A1-1
        
        public User user { get; set; }


        /*public Player Player { get; set; }
        public Admin Admin { get; set; }*/
    }
}