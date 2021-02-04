using System;
using System.Collections.Generic;
using System.IO;
using Api.Domain.DTOs;
using Api.Domain.Validation;

namespace Api.Domain.Contracts.Services
{
    public interface IImportationService
    {
        IEnumerable<ImportationResponseDto> InsertImportations(Stream stream);

        IEnumerable<ImportationListResponseDto> GetImportations();
        ImportationResponseDto GetImportation(int id);

        IEnumerable<ValidationError> GetValidationErrors();
        bool IsValid();
    }
}