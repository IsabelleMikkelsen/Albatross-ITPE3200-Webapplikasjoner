using System;

namespace Albatross.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public int ModuleLevel { get; set; }
        public string ModuleName { get; set; } = string.Empty;//Add defualt value
        
        public User user { get; set; } = null!; //Null-forgiving operator


        /*public Player Player { get; set; }
        public Admin Admin { get; set; }*/
    }
}