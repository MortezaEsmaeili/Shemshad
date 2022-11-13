namespace Entities.Exceptions;

public sealed class SchoolNotFoundException : NotFoundException
{
	public SchoolNotFoundException(Guid schoolId)
		: base($"The school with id: {schoolId} doesn't exist in the database.")
	{
	}
}
