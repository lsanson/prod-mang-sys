using System;
using System.Collections.Generic;
using Api.Domain.DTOs;

namespace Api.Domain.Contracts.Services
{
    public interface IImportationService
    {
        IEnumerable<ImportationResponseDto> InsertImportations();

        IEnumerable<ImportationResponseDto> GetImportations();
        ImportationResponseDto GetImportation(Guid id);
    }
}