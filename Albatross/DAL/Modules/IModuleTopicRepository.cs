using Albatross.Models;

namespace Albatross.DAL;

public interface IModuleTopicRepository
{
    Task<IEnumerable<ModuleTopic>> GetAll();
    Task<ModuleTopic?> GetModuleTopicById(int id);
    Task Create(ModuleTopic moduleTopic);
    Task Update(ModuleTopic moduleTopic);
    Task<bool> Delete(int id);
}