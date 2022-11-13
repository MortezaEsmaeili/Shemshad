using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<ISchoolRepository> _schoolRepository;
	private readonly Lazy<IStudentRepository> _studentRepository;

	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
        _schoolRepository = new Lazy<ISchoolRepository>(() =>
		new SchoolRepository(repositoryContext));
        _studentRepository = new Lazy<IStudentRepository>(() =>
		new StudentRepository(repositoryContext));
	}

	public ISchoolRepository School => _schoolRepository.Value;
	public IStudentRepository Student => _studentRepository.Value;

	public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
