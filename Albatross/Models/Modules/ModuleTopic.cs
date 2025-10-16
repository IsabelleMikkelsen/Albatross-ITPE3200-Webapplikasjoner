using System;
namespace Albatross.Models
{
    public class ModuleTopic
    {
        public int ModuleTopicId { get; set; }
        public string ModuleTopicName { get; set; } //Alfabet
        
        public int ModuleId { get; set; }
        
        public Module Module { get; set; }

        
    }
}