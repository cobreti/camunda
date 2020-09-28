using System;
using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


namespace TestClient.Camunda
{
    public class CamundaWorker<WORKER> : IExternalTaskAdapter
    {
        protected IServiceProvider ServiceProvider {get;}
        protected ILogger<WORKER> Logger {get;}
        public CamundaWorker()
        {
            ServiceProvider = CamundaClient.Instance.ServiceProvider;
            Logger = ServiceProvider.GetService<ILogger<WORKER>>();

            Logger.LogInformation("Starting");
        }

        public virtual void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            throw new NotImplementedException();
        }
    }
}