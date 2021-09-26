using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using Webjobs.Managers;

namespace Webjobs.Services
{
    public interface IBatService
    {
        void Sample1();
    }

    public class BatService : IBatService
    {
        private readonly IWebjobsConfigManager conf;
        private readonly ILogger<BatService> logger;

        public BatService(ILogger<BatService> logger, IOptions<WebjobsConfigManager> options)
        {
            conf = options.Value;
            this.logger = logger;
        }

        public void Sample1()
        {
            try
            {
                logger.LogInformation($"conf.AppVal1:{conf.AppVal1}, conf.ConnString:{conf.ConnString}");
                throw new NotImplementedException();
                logger.LogInformation("[SUCCESS] Sample1.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "[ERROR] Sample1.");
            }
        }
    }
}
