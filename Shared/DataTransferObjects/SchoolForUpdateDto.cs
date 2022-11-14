namespace Shared.DataTransferObjects;

public record SchoolForUpdateDto(string Name, string Address, string country,
        IEnumerable<StudentForCreationDto>? Students);
