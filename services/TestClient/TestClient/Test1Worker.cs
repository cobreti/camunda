using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;

namespace TestClient
{
    [ExternalTaskTopic("test-1")]
    public class Test1Worker : IExternalTaskAdapter
    {
        public Test1Worker()
        {
            
        }
        
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            int status = 0;
            resultVariables.Add("newValue", "result value");
            resultVariables.Add("otherValue", "second check");
            resultVariables.Add("teststatus", status);
        }
    }
}