using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record StudentForManipulationDto
{
	[Required(ErrorMessage = "Student name is a required field.")]
	[MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
	public string? Name { get; init; }

	[Range(6, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 6")]
	public int Age { get; init; }

	[Required(ErrorMessage = "Class is a required field.")]
    [Range(6, int.MaxValue, ErrorMessage = "Class is required and it can't be lower than 1")]
    public int eClass { get; init; }
}
