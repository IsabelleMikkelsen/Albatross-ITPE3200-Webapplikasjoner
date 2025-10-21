using Microsoft.AspNetCore.Mvc;
using Albatross.Models;
using System.Security.Cryptography.X509Certificates;

namespace Albatross.Controllers
{
    public class QuizController : Controller
    {
       public IActionResult A1()
         {
            var questions = new List<Question>
              {
                  new Question
                  {
                      Id = 1,
                      QuestionSentence = "Hva betyr 'Mirëdita' på albansk?", 
                      Options = new List<string> { "God morgen", "God dag", "Ha det", "Hvordan går det?" },
                      CorrectOptionIndex = "God dag"
                  },
                  new Question
                  {
                      Id = 2,
                      QuestionSentence= "Hva betyr 'Mirëdita' på albansk?",
                      Options = new List<string> { "God morgen", "God dag", "Ha det", "Hvordan går det?" },
                      CorrectOptionIndex = "God dag"
                  }
              };
            return View(questions);
            }
            // resulatatet av quizen kan håndteres her

            public IActionResult Result(int score, int total)
            {
                ViewBag.Score = score;
                ViewBag.Total = total;
                return View();
            }

         }
    }
