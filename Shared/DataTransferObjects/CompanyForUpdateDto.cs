namespace Shared.DataTransferObjects;

public record CompanyForUpdateDto : CompanyForManipulationDto
{
	public IEnumerable<StudentForCreationDto>? Employees { get; init; }
}
