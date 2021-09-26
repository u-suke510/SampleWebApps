using Libs.Managers;

namespace Webjobs.Managers
{
    public interface IWebjobsConfigManager : IConfigManager
    {
        string AppVal1
        {
            get;
        }
    }

    public class WebjobsConfigManager : ConfigManager, IWebjobsConfigManager
    {
        public string AppVal1
        {
            get;
            set;
        }
    }
}
