using System;
using OODProjectServer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace OODProjectServer.Helpers
{
    public class MyDependency : IMyDependency
    {
        public MyDependency(IServiceCollection services)
        {

        }
    }
}
