using System;
using System.Collections.Generic;
using System.IO;
using Api.Domain.DTOs;
using Microsoft.AspNetCore.Http;

namespace Api.Domain.Contracts.Services
{
    public interface IImportationService
    {
        IEnumerable<ImportationResponseDto> InsertImportations(Stream stream);

        IEnumerable<ImportationResponseDto> GetImportations();
        ImportationResponseDto GetImportation(Guid id);
    }
}