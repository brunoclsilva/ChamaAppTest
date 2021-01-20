using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using CourseSignUp.Api.Courses;
using Newtonsoft.Json;

namespace SignUpConsumer
{
    class Program
    {
        static string connectionString = "Host= AzureSBHost; user= user; pass=pass";
        static string queueName = "SignUpQueue";

        static async Task Main()
        {
            await ReceiveMessagesAsync();
        }

        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");

            var signUpCourse = JsonConvert.DeserializeObject<SignUpToCourseDto>(body);

            //process the msg and verify if the student is able to enter the course based in some rules as capacity of the course, etc.

            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        static async Task ReceiveMessagesAsync()
        {
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
                processor.ProcessMessageAsync += MessageHandler;

                processor.ProcessErrorAsync += ErrorHandler;

                await processor.StartProcessingAsync();

                await processor.StopProcessingAsync();
            } 
        }
    }
}
