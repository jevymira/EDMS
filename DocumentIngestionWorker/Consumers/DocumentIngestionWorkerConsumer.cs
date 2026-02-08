namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;
    using Tesseract;

    public class DocumentIngestionWorkerConsumer :
        IConsumer<IngestDocument>
    {
        public Task Consume(ConsumeContext<IngestDocument> context)
        {
            string text;

            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(context.Message.DocumentName))
                {
                    using (var page = engine.Process(img))
                    {
                        text = page.GetText();
                    }
                }
            }

            System.Console.WriteLine(text);

            return Task.CompletedTask;
        }
    }
}