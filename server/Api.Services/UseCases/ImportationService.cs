using System;
using System.Collections.Generic;
using Api.Domain.Contracts.Services;
using Api.Domain.DTOs;

namespace Api.Services.UseCases
{
    public class ImportationService : IImportationService
    {
        public ImportationResponseDto GetImportation(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImportationResponseDto> GetImportations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImportationResponseDto> InsertImportations()
        {
            throw new NotImplementedException();
        }
    }
}