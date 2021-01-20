using CourseSignUp.Domain.Interfaces.Service;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

namespace CourseSignUp.Service.Service
{
    public class QueueService : IQueueService
    {
        private IConfiguration _configuration;
        private ILogger _logger;
        public QueueService(IConfiguration config, ILogger logger)
        {
            _configuration = config;
            _logger = logger;
        }

        public void SendMessage(string message)
        {
            var client = new QueueClient(
                _configuration.GetConnectionString("AzureServiceBus"),
                "QueueDestination",
                ReceiveMode.ReceiveAndDelete);


            var body = Encoding.UTF8.GetBytes(message);
            client.SendAsync(new Message(body)).Wait();

            _logger.LogInformation($"Azure Service Bus - " + $"Queue: QueDestination - Mensagem enviada: {message}");
        }
    }
}
