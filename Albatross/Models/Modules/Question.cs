using System;
namespace Albatross.Models
{
    public class Question
    {
         public int Id { get; set; }
        public string QuestionSentence { get; set; }
        public List<string> Options { get; set; }
        public string CorrectOptionIndex { get; set; }

        //Path (img/lyd)
        //Path (img/lyd)

        
        
       // public ATask ATask { get; set; }
       //public AnswerOption AnswerOption { get; set; }
    }
}