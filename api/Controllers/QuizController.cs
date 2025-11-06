using Microsoft.AspNetCore.Mvc;
using Albatross.Models;
using System.Security.Cryptography.X509Certificates;

namespace Albatross.Controllers
{
    public class QuizController : Controller
    {
        private readonly ItemDbContext _context;

        public QuizController(ItemDbContext context)
        {
            _context = context;
        }

        public IActionResult A1Module()
        {
            return View();
        }

        //A1 Alphabet Quiz
        public IActionResult A1Alphabet()
        {
            var questions = GetA1AlphabetQuestions(); //Fetches questions from database
            return View(questions); //Returns the view with questions
        }

        //A1 Verbs Quiz
        public IActionResult A1Verbs()
        {
            var questions = GetA1VerbQuestions();
            return View(questions);
        }

        // Generic result handler
        public IActionResult A1Result(int score, int total, string quizType)
        {
            ViewBag.Score = score;
            ViewBag.Total = total;
            ViewBag.QuizType = quizType;
            return View();
        }

        // Helper methods
        private List<Question> GetA1AlphabetQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Id = 1,
                    QuestionSentence = "Hva betyr 'Mirëdita' på albansk?",
                    Options = new List<string> { "God morgen", "God dag", "Ha det", "Hvordan går det?" },
                    CorrectOptionIndex = "God dag"
                },
                // Add more questions
            };
        }

        private List<Question> GetA1VerbQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Id = 1,
                    QuestionSentence = "Hva betyr 'jam' (å være) på norsk?",
                    Options = new List<string> { "Jeg er", "Jeg har", "Jeg går", "Jeg ser" },
                    CorrectOptionIndex = "Jeg er"
                },
                // Add more verb questions
            };
        }
    }
}

        