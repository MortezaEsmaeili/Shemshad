using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public StudentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StudentDto> GetStudentAsync(Guid schoolId, Guid id, bool trackChanges)
        {
            var school = await _repository.School.GetSchoolAsync(schoolId,trackChanges);
            if (school == null)
                throw new SchoolNotFoundException(schoolId);
            var studentDb = await _repository.Student.GetStudentAsync(schoolId,id,trackChanges);
            if (studentDb == null)
                throw new StudentNotFoundException(id);

            var studentDto = _mapper.Map<StudentDto>(studentDb);
            return studentDto;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync(Guid schoolId, bool trackChanges)
        {
            var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);
            if(school == null)
                throw new SchoolNotFoundException(schoolId);
            var studentsFromDb =
                await _repository.Student.GetStudentsAsync(schoolId,trackChanges);
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(studentsFromDb);
            return studentsDto;
        }
    }
}
