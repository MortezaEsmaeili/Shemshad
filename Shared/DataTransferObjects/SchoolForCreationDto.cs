namespace Shared.DataTransferObjects;

public record SchoolForCreationDto : SchoolForManipulationDto
{
    IEnumerable<StudentForCreationDto>? Students { get; init; }
}
