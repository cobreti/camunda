using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;

namespace TestClient
{
    [ExternalTaskTopic("test-2")]
    public class Test2Worker : IExternalTaskAdapter
    {
        public Test2Worker()
        {
            
        }
        
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            resultVariables.Add("newValue", "result value");
        }
    }
}