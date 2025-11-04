using Microsoft.EntityFrameworkCore;
using Albatross.Models;

namespace Albatross.DAL;

public class ModuleTopicRepository : IModuleTopicRepository
{
    private readonly ItemDbContext _db;

    public ModuleTopicRepository(ItemDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<ModuleTopic>> getAll()
    {
        return await _db.ModuleTopics.ToListAsync();
    }

    public async Task<ModuleTopic?> GetModuleTopicById(int id)
    {
        return await _db.ModuleTopics.FindAsync(id);
    }

    public async Task Create(ModuleTopic moduleTopic)
    {
        _db.ModuleTopics.Add(moduleTopic);
        await _db.SaveChangesAsync();
    }

    public async Task Update(ModuleTopic moduleTopic)
    {
        _db.ModuleTopics.Update(moduleTopic);
        await _db.SaveChangesAsync();
    }
    
    public async Task<bool> Delete(int id)
    {
        var moduleTopic = await _db.ModuleTopics.FindAsync(id);
        if (moduleTopic == null)
        {
            return false;
        }

        _db.ModuleTopics.Remove(moduleTopic);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ModuleTopic>> GetAll()
{
    return await _db.ModuleTopics.ToListAsync();
}
}