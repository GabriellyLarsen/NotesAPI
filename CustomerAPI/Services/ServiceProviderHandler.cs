using System.Diagnostics.CodeAnalysis;

namespace NotesAPI.Services
{
    public interface IServiceProviderHandler
    {
        T GetRequiredService<T>();
    }

    [ExcludeFromCodeCoverage]
    public class ServiceProviderHandler : IServiceProviderHandler
    {
        private readonly IServiceProvider _serviceProvider;
        public ServiceProviderHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T GetRequiredService<T>()
        {
            return (T)_serviceProvider.GetRequiredService(typeof(T));
        }
    }
}
