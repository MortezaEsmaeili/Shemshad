//using Shared.DataTransferObjects;

using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ISchoolService
{
	Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync(bool trackChanges);
	Task<SchoolDto> GetSchoolAsync(Guid schoolId, bool trackChanges);
	Task<SchoolDto> CreateSchoolAsync(SchoolForCreationDto school);
	Task<IEnumerable<SchoolDto>> GetByIdsAsync(IEnumerable<Guid> ids,
		bool trackChanges);
	Task<(IEnumerable<SchoolDto> schools, string ids)> CreateSchoolCollectionAsync
		(IEnumerable<SchoolForCreationDto> schoolCollection);
	Task DeleteSchoolAsync(Guid schoolId, bool trackChanges);
	Task UpdateSchoolAsync(Guid schoolId, SchoolForUpdateDto schoolForUpdate,
		bool trackChanges);
}
