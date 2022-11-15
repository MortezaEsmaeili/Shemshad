namespace Shared.DataTransferObjects;

public record SchoolForUpdateDto : SchoolForManipulationDto
{
    IEnumerable<StudentForCreationDto>? Students { get; set; }
}
