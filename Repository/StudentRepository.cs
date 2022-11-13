using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

internal sealed class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
	public StudentRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public async Task<PagedList<Student>> GetStudentsAsync(Guid schoolID,
		StudentParameters studentParameters, bool trackChanges)
	{
		var employees = await FindByCondition(e => e.SchoolId.Equals(schoolID), trackChanges)
			.FilterEmployees(studentParameters.MinAge, studentParameters.MaxAge)
			.Search(studentParameters.SearchTerm!)
			.Sort(studentParameters.OrderBy!)
			.ToListAsync();

		return PagedList<Student>
			.ToPagedList(employees, studentParameters.PageNumber, studentParameters.PageSize);
	}

	public async Task<Student> GetStudentAsync(Guid schoolID, Guid id, bool trackChanges) =>
		await FindByCondition(e => e.SchoolId.Equals(schoolID) && e.Id.Equals(id), trackChanges)
		.SingleOrDefaultAsync();

	public void CreateEmployeeForCompany(Guid schoolID, Student student)
	{
        student.SchoolId = schoolID;
		Create(student);
	}

	public void DeleteEmployee(Student student) => Delete(student);
}
