using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.Extensions.Hosting;

namespace Management
{
    public class WorkflowManager : IHostedService, IDisposable
    {
        private Thread _thread;

        private delegate Task ListenerDelegate();
        private event ListenerDelegate ListenerEvent;
        
        public WorkflowManager()
        {
            ListenerEvent += Listen;
        }
        
        public void Dispose()
        {
            _thread.Interrupt();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _thread = new Thread(CreateWorkflow);
            _thread.Start();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            
        }

        private void CreateWorkflow()
        {
            ListenerEvent.Invoke();
        }

        private async Task Listen()
        {
            var server = new HttpListener();
            server.Prefixes.Add("http://127.0.0.1:5000/engine/");
            server.Start();
            
            var context = await server.GetContextAsync();
 
            var response = context.Response;
            string responseText =
                @"<!DOCTYPE html>
                <html>
                    <head>
                        <meta charset='utf8'>
                        <title>METANIT.COM</title>
                    </head>
                    <body>
                        <h2>Hello METANIT.COM</h2>
                    </body>
                </html>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseText);
            response.ContentLength64 = buffer.Length;
            using Stream output = response.OutputStream;
            await output.WriteAsync(buffer);
            await output.FlushAsync();
            
            server.Stop();
            server.Close();

            CreateWorkflow();
        }
    }
}
