using Albatross.Models;

namespace Albatross.DAL;

public interface INewQuizRepository
{
    Task<IEnumerable<NewQuiz>> GetAll();
    Task<NewQuiz?> GetNewQuizById(int id);
    Task Create(NewQuiz newQuiz);
    Task Update(NewQuiz newQuiz);
    Task<bool> Delete(int id);
}