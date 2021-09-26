namespace Libs.Managers
{
    public interface IConfigManager
    {
        string ConnString
        {
            get;
        }
    }

    public class ConfigManager : IConfigManager
    {
        public string ConnString
        {
            get;
            set;
        }
    }
}
