namespace Company.Consumers
{
    using MassTransit;

    public class DocumentIngestionWorkerConsumerDefinition :
        ConsumerDefinition<DocumentIngestionWorkerConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<DocumentIngestionWorkerConsumer> consumerConfigurator, IRegistrationContext context)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));

            endpointConfigurator.UseInMemoryOutbox(context);
        }
    }
}