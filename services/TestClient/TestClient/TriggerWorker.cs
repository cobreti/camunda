using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;

namespace TestClient
{
    [ExternalTaskTopic("trigger")]
    public class TriggerWorker : IExternalTaskAdapter
    {
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            int processToStart = 1;
            
            resultVariables.Add("processToStart", processToStart);
        }
    }
}