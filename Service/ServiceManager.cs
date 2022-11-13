using AutoMapper;
using Contracts;
using Service.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    { 
        private readonly Lazy<ISchoolService> _schoolService;
        private readonly Lazy<IStudentService> _studentService;

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerManager  logger, IMapper mapper)
        {
            _schoolService = new Lazy<ISchoolService>(() => new
            SchoolService(repositoryManager, logger, mapper));

            _studentService = new Lazy<IStudentService>(() => new
            StudentService(repositoryManager, logger, mapper));
        }
        public ISchoolService SchoolService => _schoolService.Value;
        public IStudentService StudentService => _studentService.Value;
    }
}
