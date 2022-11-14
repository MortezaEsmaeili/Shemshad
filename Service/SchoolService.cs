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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service
{
    internal sealed class SchoolService : ISchoolService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SchoolService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<SchoolDto> CreateSchoolAsync(SchoolForCreationDto school)
        {
            var schoolEntity = _mapper.Map<School>(school);

            _repository.School.CreateSchool(schoolEntity);
            await _repository.SaveAsync();

            var schoolToReturn = _mapper.Map<SchoolDto>(schoolEntity);
            return schoolToReturn;
        }

        public async Task<(IEnumerable<SchoolDto> schools, string ids)> CreateSchoolCollectionAsync(IEnumerable<SchoolForCreationDto> schoolCollection)
        {
            if (schoolCollection == null)
                throw new SchoolCollectionBadRequest();

            var schoolEntities = _mapper.Map<IEnumerable<School>>(schoolCollection);
            foreach(var school in schoolEntities)
            {
                 _repository.School.CreateSchool(school);
            }
            await _repository.SaveAsync();

            var schoolCollectionToReturn = 
                _mapper.Map<IEnumerable<SchoolDto>>(schoolEntities);

            var ids = string.Join(", ", schoolCollectionToReturn.Select(s => s.Id));
            return (schools: schoolCollectionToReturn, ids: ids);
        }

        public async Task DeleteSchoolAsync(Guid schoolId, bool trackChanges)
        {
            var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

            if (school is null)
                throw new SchoolNotFoundException(schoolId);

            _repository.School.DeleteSchool(school);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync(bool trackChanges)
        {
            var schools =
                await  _repository.School.GetAllSchoolsAsync(trackChanges);
                
            var schoolsDto = _mapper.Map<IEnumerable<SchoolDto>>(schools);
            return schoolsDto;
        }

        public async Task<IEnumerable<SchoolDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();
            var schoolsEntity = await _repository.School.GetByIdsAsync(ids, trackChanges);
            if(ids.Count() != schoolsEntity.Count())
                throw new CollectionByIdsBadRequestException();

            var schoolsToReturn = _mapper.Map<IEnumerable<SchoolDto>>(schoolsEntity);
            return schoolsToReturn;
        }

        public async Task<SchoolDto> GetSchoolAsync(Guid id, bool trackChanges)
        {
            var school = await _repository.School.GetSchoolAsync(id, trackChanges);
            
            if (school is null)
                throw new SchoolNotFoundException(id);

            var schoolDTO = _mapper.Map<SchoolDto>(school);
            return schoolDTO; 
        }

        public async Task UpdateSchoolAsync(Guid schoolId, SchoolForUpdateDto schoolForUpdate,
            bool trackChanges)
        {
            var schoolEntity = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

            if (schoolEntity is null)
                throw new SchoolNotFoundException(schoolId);

            _mapper.Map(schoolForUpdate, schoolEntity);
            await _repository.SaveAsync();
        }
    }
}
