namespace Shared.DataTransferObjects;

public record SchoolForCreationDto(string Name, string Address, string Country,
    IEnumerable<StudentForCreationDto>? Students);
