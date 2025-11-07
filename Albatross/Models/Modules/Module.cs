using System;

namespace Albatross.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; } = string.Empty;//Add defualt value
        public ICollection<ModuleTopic> ModuleTopics { get; set; } = new List<ModuleTopic>();
        public User user { get; set; } = null!; //Null-forgiving operator


        /*public Player Player { get; set; }
        public Admin Admin { get; set; }*/
    }
}