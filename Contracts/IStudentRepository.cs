using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IStudentRepository
{
	Task<IEnumerable<Student>> GetStudentsAsync(Guid schoolId,
         bool trackChanges);
	Task<Student> GetStudentAsync(Guid schoolId, Guid id, bool trackChanges);
	void CreateStudentForCompany(Guid schoolId, Student student);
	void DeleteStudent(Student student);
}
