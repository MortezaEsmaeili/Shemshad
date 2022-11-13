namespace Service.Contracts;

public interface IServiceManager
{
	ISchoolService SchoolService { get; }
	IStudentService StudentService { get; }
	//IAuthenticationService AuthenticationService { get; }
}
