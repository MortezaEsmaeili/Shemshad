using Contracts;
using Entities.Models;
using Service.Contracts;
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

        public SchoolService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<IEnumerable<School>> GetAllSchoolsAsync(bool trackChanges)
        { 
            try 
            { 
                var schools =
                  await  _repository.School.GetAllSchoolsAsync(trackChanges);
                return schools;
            } 
            catch (Exception ex) 
            { 
                _logger.LogError($"Something went wrong in the {nameof(GetAllSchoolsAsync)} service method {ex}");
                throw;
            }
        }
    }
}
