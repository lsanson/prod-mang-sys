using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Api.Domain.Contracts.Services;
using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Infra.UnitOfWork;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;

namespace Api.Services.UseCases
{
    public class ImportationService : IImportationService
    {
        private IUnitOfWork _unitOfWork;

        public ImportationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ImportationResponseDto GetImportation(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImportationResponseDto> GetImportations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImportationResponseDto> InsertImportations(Stream stream)
        {
            if (stream == null)
            {
                return null;
            }

            var newImportations = new List<Importation>();

            List<string> headers = null;
            using(var workBook = new XLWorkbook(stream))
            {
                var worksheet = workBook.Worksheet(1);
                bool firstRow = true;
                // string readRange = "1:1";
                string readRange = string.Format("{0}:{1}", 1, worksheet.FirstRowUsed().LastCellUsed().Address.ColumnNumber);
                foreach (var row in worksheet.RowsUsed())
                {
                    if (firstRow)
                    {
                        headers = row.Cells(readRange).Select(x => x.Value.ToString().Trim()).ToList();
                        firstRow = false;
                    }
                    else {
                        int cellIndex = 0;
                        var tuple = new Dictionary<string, object>();

                        foreach (var cell in row.Cells(readRange))
                        {
                            tuple.Add(headers.ElementAt(cellIndex++), cell.Value);
                        }
                        var importation = new Importation(Convert.ToString(tuple["Nome do Produto"]), 
                                                        Convert.ToInt32(tuple["Quantidade"]), 
                                                        Math.Round(Convert.ToDecimal(tuple["Valor Unitário"]), 2), 
                                                        Convert.ToDateTime(tuple["Data Entrega"]));
                        var validationResult = importation.Validate();
                        if (validationResult.IsValid)
                        {
                            newImportations.Add(importation);
                        }
                    }
                }
                // determine if excel is empty
            }
            var result = _unitOfWork.GetImportationRepository().InsertList(newImportations);
            return result.Select(x => (ImportationResponseDto)x);
        }
    }
}