using System;
using CamundaClient;

namespace TestClient
{
    public class CamundaClient
    {
        private CamundaEngineClient camunda;

        public CamundaClient()
        {
            camunda = new CamundaEngineClient(
                new Uri("http://192.168.1.225/engine-rest/engine/default/"), null, null);
        }

        public void Run()
        {
            camunda.Startup();
        }
    }
}