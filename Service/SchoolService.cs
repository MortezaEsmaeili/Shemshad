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
        public async Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync(bool trackChanges)
        {
            var schools =
                await  _repository.School.GetAllSchoolsAsync(trackChanges);
                
            var schoolsDto = _mapper.Map<IEnumerable<SchoolDto>>(schools);
            return schoolsDto;
        }
        public async Task<SchoolDto> GetSchoolAsync(Guid id, bool trackChanges)
        {
            var school = await _repository.School.GetSchoolAsync(id, trackChanges);
            
            if (school is null)
                throw new SchoolNotFoundException(id);

            var schoolDTO = _mapper.Map<SchoolDto>(school);
            return schoolDTO; 
        }
    }
}
