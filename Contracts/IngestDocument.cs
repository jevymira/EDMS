namespace Contracts
{
    public record IngestDocument
    {
        public required string DocumentName { get; init; }
    }
}
