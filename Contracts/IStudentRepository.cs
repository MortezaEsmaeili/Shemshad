using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IStudentRepository
{
	Task<PagedList<Student>> GetStudentsAsync(Guid schoolId,
        StudentParameters studentParameters, bool trackChanges);
	Task<Student> GetStudentAsync(Guid companyId, Guid id, bool trackChanges);
	void CreateEmployeeForCompany(Guid companyId, Student student);
	void DeleteEmployee(Student student);
}
