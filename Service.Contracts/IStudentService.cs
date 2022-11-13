//using Entities.LinkModels;
//using Entities.Models;
//using Shared.DataTransferObjects;
//using Shared.RequestFeatures;

using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IStudentService
{
	Task<IEnumerable<StudentDto>> GetStudentsAsync(Guid schoolId,
		 bool trackChanges);
	Task<StudentDto> GetStudentAsync(Guid schoolId, Guid id, bool trackChanges);
/*	Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId,
		EmployeeForCreationDto employeeForCreation, bool trackChanges);
	Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges);
	Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id,
		EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);
	Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(
		Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
	Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
*/
}
