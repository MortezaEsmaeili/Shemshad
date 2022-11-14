namespace Entities.Exceptions;

public sealed class SchoolCollectionBadRequest : BadRequestException
{
	public SchoolCollectionBadRequest()
		: base("School collection sent from a client is null.")
	{
	}
}
