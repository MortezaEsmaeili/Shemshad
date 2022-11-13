//using Shared.DataTransferObjects;

using Entities.Models;

namespace Service.Contracts;

public interface ISchoolService
{
	Task<IEnumerable<School>> GetAllSchoolsAsync(bool trackChanges);
/*	Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges);
	Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);
	Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
	Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync
		(IEnumerable<CompanyForCreationDto> companyCollection);
	Task DeleteCompanyAsync(Guid companyId, bool trackChanges);
	Task UpdateCompanyAsync(Guid companyid, CompanyForUpdateDto companyForUpdate, bool trackChanges);
*/
}
