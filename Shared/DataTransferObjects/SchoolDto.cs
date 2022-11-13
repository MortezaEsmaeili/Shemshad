namespace Shared.DataTransferObjects;

public record SchoolDto
{
	public Guid Id { get; init; }
	public string? Name { get; init; }
	public string? FullAddress { get; init; }
}
