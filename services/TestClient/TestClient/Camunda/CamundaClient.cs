using System;
using CamundaClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TestClient.Camunda
{
    public class CamundaClient : ICamundaClient
    {
        private CamundaEngineClient camunda;

        private Configuration.Camunda CamundaSettings { get; }

        private ILogger Logger { get; }

        public CamundaClient(
            ILogger<CamundaClient> logger, 
            IOptions<Configuration.Camunda> camundaSettingsOptions)
        {
            CamundaSettings = camundaSettingsOptions.Value;
            Logger = logger;

            Logger.LogInformation($"using camunda server : {CamundaSettings.Server}");

            // camunda = new CamundaEngineClient(
            //     //new Uri("http://camunda.danny-thibaudeau.ca/engine-rest/engine/default/"), 
            //     new Uri(CamundaSettings.Server),
            //     null, null);
        }

        public void Run()
        {
            camunda.Startup();
        }
    }
}
