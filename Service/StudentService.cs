using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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

        public async Task<StudentDto> CreateStudentForSchoolAsync(Guid schoolId, StudentForCreationDto StudentForCreation, bool trackChanges)
        {
            var school = await _repository.School.GetSchoolAsync(schoolId,trackChanges);
            if(school == null)
                throw new SchoolNotFoundException(schoolId);

            var studentEntity = _mapper.Map<Student>(StudentForCreation);
            _repository.Student.CreateStudentForSchool(schoolId, studentEntity);
            await _repository.SaveAsync();

            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return studentToReturn;
        }

        public async Task DeleteStudentForSchoolAsync(Guid schoolId, Guid id, bool trackChanges)
        {
            var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);
            if (school == null)
                throw new SchoolNotFoundException(schoolId);
            var studentDb = await _repository.Student.GetStudentAsync(schoolId, id, trackChanges);
            if (studentDb == null)
                throw new StudentNotFoundException(id);

            _repository.Student.DeleteStudent(studentDb);
            await _repository.SaveAsync();

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

        public async Task UpdateStudentForSchoolAsync(Guid schoolId, Guid id, 
            StudentForUpdateDto studentForUpdate, bool schTrackChanges, bool stuTrackChanges)
        {
            var school = await _repository.School.GetSchoolAsync(schoolId, schTrackChanges);
            if (school == null)
                throw new SchoolNotFoundException(schoolId);

            var studentEntity = await _repository.Student.GetStudentAsync(schoolId,id, stuTrackChanges);
            if(studentEntity is null)
                throw new StudentNotFoundException(id);

            _mapper.Map(studentForUpdate, studentEntity);
            await _repository.SaveAsync();
        }
    }
}
