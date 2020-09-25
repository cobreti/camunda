using System;
using CamundaClient;

namespace TestClient
{
    public class CamundaClient
    {
        private CamundaEngineClient camunda;

        private Configuration.Camunda CamundaSettings {get;}

        public CamundaClient(Configuration.Camunda camundaSettings)
        {
            CamundaSettings = camundaSettings;
            camunda = new CamundaEngineClient(
                new Uri("http://camunda.danny-thibaudeau.ca/engine-rest/engine/default/"), null, null);
        }

        public void Run()
        {
            camunda.Startup();
        }
    }
}
