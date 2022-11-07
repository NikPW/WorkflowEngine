using Microsoft.Extensions.Hosting;

namespace Management
{
    public class Manager : IHostedService, IDisposable
    {
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            
        }
    }
}
