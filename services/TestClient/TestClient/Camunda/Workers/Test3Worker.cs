using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;
using Microsoft.Extensions.Logging;


namespace TestClient.Camunda.Workers
{
    [ExternalTaskTopic("test-3")]
    public class Test3Worker : CamundaWorker<Test3Worker>
    {
        public Test3Worker()
        {

        }

        public override void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            Logger.LogInformation("Executing external task");
        }
    }
}