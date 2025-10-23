using Albatross.Models;

namespace Albatross.ViewModels
{
    public class NullModuleTopViewModel
    {

        public IEnumerable<NullModuleTopic> NullModuleTopics;  //{get; set;}

        public string? CurrentViewName; //{get; set;}

        public NullModuleTopViewModel(IEnumerable<NullModuleTopic> nullmoduleTopics, string? currentViewName)
        {
            NullModuleTopics = nullmoduleTopics;
            CurrentViewName = currentViewName;
        }
    }
}