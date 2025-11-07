using Microsoft.EntityFrameworkCore;
using Albatross.Models;

namespace Albatross.DAL;

public class NewQuizRepository : INewQuizRepository
{
    private readonly ItemDbContext _db;

    public NewQuizRepository(ItemDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<NewQuiz>> getAll()
    {
        return await _db.NewQuizzes.ToListAsync();
    }

    public async Task<NewQuiz?> GetNewQuizById(int id)
    {
        return await _db.NewQuizzes.FindAsync(id);
    }

    public async Task Create(NewQuiz newQuiz)
    {
        _db.NewQuizzes.Add(newQuiz);
        await _db.SaveChangesAsync();
    }

    public async Task Update(NewQuiz newQuiz)
    {
        _db.NewQuizzes.Update(newQuiz);
        await _db.SaveChangesAsync();
    }
    
    public async Task<bool> Delete(int id)
    {
        var newQuiz = await _db.NewQuizzes.FindAsync(id);
        if (newQuiz == null)
        {
            return false;
        }

        _db.NewQuizzes.Remove(newQuiz);
        await _db.SaveChangesAsync();
        return true;
    }

    //public Task<IEnumerable<Item>> GetAll()
    //{
      //  throw new NotImplementedException();
    //}

    public async Task<IEnumerable<NewQuiz>> GetAll()
{
    return await _db.NewQuizzes.ToListAsync();
}
}