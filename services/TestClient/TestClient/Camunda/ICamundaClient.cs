using System;

namespace TestClient.Camunda
{
    public interface ICamundaClient
    {
        void Run();
        IServiceProvider ServiceProvider {get;}
    }
}