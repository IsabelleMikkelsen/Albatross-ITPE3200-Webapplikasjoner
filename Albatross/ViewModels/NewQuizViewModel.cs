using Albatross.Models;

namespace Albatross.ViewModels
{
    public class NewQuizViewModel
    {

        public IEnumerable<NewQuiz> NewQuizzes;  //{get; set;}

        public string? CurrentViewName; //{get; set;}

        public NewQuizViewModel(IEnumerable<NewQuiz> newQuizzes, string? currentViewName)
        {
            NewQuizzes = newQuizzes;
            CurrentViewName = currentViewName;
        }
    }
}