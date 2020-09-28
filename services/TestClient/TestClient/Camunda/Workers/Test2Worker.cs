using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;
using Microsoft.Extensions.Logging;


namespace TestClient.Camunda.Workers
{
    [ExternalTaskTopic("test-2")]
    public class Test2Worker : CamundaWorker<Test2Worker>
    {
        public Test2Worker()
        {

        }

        public override void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            Logger.LogInformation("Executing external task");

            resultVariables.Add("newValue", "result value");
        }
    }
}