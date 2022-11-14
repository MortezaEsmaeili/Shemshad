//using Shared.DataTransferObjects;

using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ISchoolService
{
	Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync(bool trackChanges);
	Task<SchoolDto> GetSchoolAsync(Guid schoolId, bool trackChanges);
	Task<SchoolDto> CreateCompanyAsync(SchoolForCreationDto school);
/*	Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
	Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync
		(IEnumerable<CompanyForCreationDto> companyCollection);
	Task DeleteCompanyAsync(Guid companyId, bool trackChanges);
	Task UpdateCompanyAsync(Guid companyid, CompanyForUpdateDto companyForUpdate, bool trackChanges);
*/
}
