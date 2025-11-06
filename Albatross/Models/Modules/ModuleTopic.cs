using System;

namespace Albatross.Models
{
    public class ModuleTopic
    {
        public int ModuleTopicId { get; set; }
        public string ModuleTopicName { get; set; } = string.Empty; //Add default value
        
        public int? ModuleId { get; set; }

        public Module? Module { get; set; } = null!;
        public ICollection<NewQuiz> NewQuizzes { get; set; } = new List<NewQuiz>();

        
    }
}