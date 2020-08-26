using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;

namespace TestClient
{
    [ExternalTaskTopic("test-3")]
    public class Test3Worker : IExternalTaskAdapter
    {
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
        }
    }
}