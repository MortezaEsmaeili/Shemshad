namespace Contracts;

public interface IRepositoryManager
{
	ISchoolRepository School { get; }
	IStudentRepository Student { get; }
	Task SaveAsync();
}
