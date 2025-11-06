using System;
namespace Albatross.Models
{
    public class NewQuiz
    {
        public int NewQuizId { get; set; }
        public string NewQuizName { get; set; }
        public int ModuleTopicId { get; set; }
        public int QuestionId { get; set; }

        //public int RewardId { get; set; }

        public ModuleTopic? ModuleTopic { get; set; } = null!;
        public ICollection<Question> Questions { get; set; } = new List<Question>();

        //public Question? Question { get; set; }
        
    }
}