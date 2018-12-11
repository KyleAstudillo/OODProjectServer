using Microsoft.Extensions.DependencyInjection;

namespace OODProjectServer.Interfaces
{
    public interface IMyDependency
    {
        string GetOktaSettings(string path);
        void setService(IServiceCollection services);
    }
}
