using System;

namespace Albatross.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionSentence { get; set; } = string.Empty; //Add default value
        public List<string> Options { get; set; } = new List<string>(); //Add default value
        public string CorrectOptionIndex { get; set; } = string.Empty; //Default value

        //Path (img/lyd)
        //Path (img/lyd)

        
        
       // public ATask ATask { get; set; }
       //public AnswerOption AnswerOption { get; set; }
    }
}