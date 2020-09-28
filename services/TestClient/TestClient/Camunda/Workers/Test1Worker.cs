using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;
using Microsoft.Extensions.Logging;

namespace TestClient.Camunda.Workers
{
    [ExternalTaskTopic("test-1")]
    public class Test1Worker : CamundaWorker<Test1Worker>
    {
        public Test1Worker()
        {
        }

        public override void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            Logger.LogInformation("Executing external task");

            int status = 0;
            resultVariables.Add("newValue", "result value");
            resultVariables.Add("otherValue", "second check");
            resultVariables.Add("teststatus", status);
        }
    }
}
