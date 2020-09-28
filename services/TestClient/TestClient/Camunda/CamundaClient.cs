using System;
using CamundaClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TestClient.Camunda
{
    public class CamundaClient : ICamundaClient
    {
        public static ICamundaClient Instance {get; private set;}

        private CamundaEngineClient camunda;

        private Configuration.Camunda CamundaSettings { get; }

        private ILogger Logger { get; }
        public IServiceProvider ServiceProvider {get;}

        public CamundaClient(
            IServiceProvider serviceProvider,
            ILogger<CamundaClient> logger, 
            IOptions<Configuration.Camunda> camundaSettingsOptions)
        {
            CamundaSettings = camundaSettingsOptions.Value;
            Logger = logger;
            ServiceProvider = serviceProvider;

            Logger.LogInformation($"using camunda server : {CamundaSettings.Server}");

            Instance = this;

            Init();
        }

        public void Run()
        {
            camunda?.Startup();
        }

        private void Init()
        {
            try
            {
                camunda = new CamundaEngineClient(
                    new Uri(CamundaSettings.Server),
                    null, null);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "failure to create camunda instance");
            }
        }
    }
}
