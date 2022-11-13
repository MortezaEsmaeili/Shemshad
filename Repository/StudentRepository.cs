using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System.Collections;
using System.ComponentModel.Design;

namespace Repository;

internal sealed class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
	public StudentRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public async Task<IEnumerable<Student>> GetStudentsAsync(Guid schoolID,
		 bool trackChanges)
	{
		var students = await FindByCondition(e => e.SchoolId.Equals(schoolID),
			trackChanges).OrderBy(e => e.Name).ToListAsync();

		return students;

    }

	public async Task<Student> GetStudentAsync(Guid schoolID, Guid id, bool trackChanges) =>
		await FindByCondition(e => e.SchoolId.Equals(schoolID) && e.Id.Equals(id), trackChanges)
		.SingleOrDefaultAsync();

	public void CreateEmployeeForCompany(Guid schoolID, Student student)
	{
        student.SchoolId = schoolID;
		Create(student);
	}

	public void DeleteStudent(Student student) => Delete(student);
}
