using System;
namespace Albatross.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int ATaskId { get; set; }
        public int AnswerOptionId { get; set; }
        public string QuestionSentence { get; set; } // Hva slags lyd er dette?

        //Path (img/lyd)
        //Path (img/lyd)

        
        
        public ATask ATask { get; set; }
       public AnswerOption AnswerOption { get; set; }
    }
}