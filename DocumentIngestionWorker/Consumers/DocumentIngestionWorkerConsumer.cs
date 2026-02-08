namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class DocumentIngestionWorkerConsumer :
        IConsumer<IngestDocument>
    {
        public Task Consume(ConsumeContext<IngestDocument> context)
        {
            System.Console.WriteLine("COMMAND RECEIVED");

            return Task.CompletedTask;
        }
    }
}