using Entities.Models;

namespace Contracts;

public interface ISchoolRepository
{
	Task<IEnumerable<School>> GetAllSchoolsAsync(bool trackChanges);
	Task<School> GetSchoolAsync(Guid schoolId, bool trackChanges);
	void CreateSchool(School school);
	Task<IEnumerable<School>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
	void DeleteSchool(School school);
}
