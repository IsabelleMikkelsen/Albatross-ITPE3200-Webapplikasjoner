using Albatross.Models;

namespace Albatross.ViewModels
{
    public class ModuleTopViewModel
    {

        public IEnumerable<ModuleTopic> ModuleTopics;  //{get; set;}

        public string? CurrentViewName; //{get; set;}

        public ModuleTopViewModel(IEnumerable<ModuleTopic> moduleTopics, string? currentViewName)
        {
            ModuleTopics = moduleTopics;
            CurrentViewName = currentViewName;
        }

        public ModuleTopViewModel(List<NullModuleTopic> nullModuleTopics, string v)
        {
        }
    }
}