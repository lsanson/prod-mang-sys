using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Contracts.Services;
using Api.Domain.DTOs;
using Api.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Api.Tests.UseCasesTests
{
    public class InsertTest
    {
        // private IImportationService _importationService;
        // private Mock<IImportationService> _serviceMock;
        // private Mock<IFormFile> _formFileMock;

        public async Task CanInsertFromFile()
        {
            await Task.Run(() => {
                // _formFileMock = new Mock<IFormFile>();
                
                // _serviceMock = new Mock<IImportationService>();
                // _serviceMock.Setup(s => s.InsertImportations(_formFileMock.Object))
                //     .Returns(new List<ImportationResponseDto>());
            });
        }
    }
}