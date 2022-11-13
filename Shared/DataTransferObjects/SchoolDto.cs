namespace Shared.DataTransferObjects;

public record SchoolDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? FullAddress { get; set; }
}

