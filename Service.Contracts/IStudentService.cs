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
	Task<StudentDto> CreateStudentForSchoolAsync(Guid schoolId,
		StudentForCreationDto StudentForCreation, bool trackChanges);
	Task DeleteStudentForSchoolAsync(Guid schoolId, Guid id, bool trackChanges);
	Task UpdateStudentForSchoolAsync(Guid SchoolId, Guid id,
		StudentForUpdateDto studentForUpdate, bool schTrackChanges, bool stuTrackChanges);
/*	Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(
		Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
	Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
*/
}
