using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Api.Domain.Contracts.Services;
using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Domain.Validation;
using Api.Infra.UnitOfWork;
using ClosedXML.Excel;

namespace Api.Services.UseCases
{
    public class ImportationService : IImportationService
    {
        private IUnitOfWork _unitOfWork;
        private List<ValidationError> _validationErrors;

        public ImportationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validationErrors = new List<ValidationError>();
        }

        public ImportationResponseDto GetImportation(Guid id)
        {
            var result = _unitOfWork.GetImportationRepository().GetImportation(id);
            return (result != null)? (ImportationResponseDto)result : null;
        }

        public IEnumerable<ImportationListResponseDto> GetImportations()
        {
            var result = _unitOfWork.GetImportationRepository().GetImportations();
            return result.OrderBy(x => x.DeliveryDate).Select(x => (ImportationListResponseDto)x);
        }

        public IEnumerable<ValidationError> GetValidationErrors()
        {
            return _validationErrors;
        }

        public IEnumerable<ImportationResponseDto> InsertImportations(Stream stream)
        {
            if (stream == null)
            {
                _validationErrors.Add(new ValidationError("Stream", "File can not be null"));
                return null;
            }

            var newImportations = new List<Importation>();

            using(var workBook = new XLWorkbook(stream))
            {
                var worksheet = workBook.Worksheet(1);
                string readRange = string.Format("{0}:{1}", 1, worksheet.FirstRowUsed().LastCellUsed().Address.ColumnNumber);
                var headers = worksheet.FirstRowUsed().Cells(readRange).Select(x => x.Value.ToString().Trim()).ToArray();
                
                var rows = worksheet.RowsUsed().ToArray();
                var count = worksheet.RowsUsed().Count();
                for (int i = 1; i < count; i++)
                {
                    var rowValues = rows[i].CellsUsed().Select(x => x.Value).ToArray();
                    string name = Convert.ToString(rowValues[1]);
                    decimal unitValue = Math.Round(Convert.ToDecimal(rowValues[3]), 2);
                    int quantity = Convert.ToInt32(rowValues[2]);
                    DateTime deliveryDate = Convert.ToDateTime(rowValues[0]);
                    var importation = new Importation(name, quantity, unitValue, deliveryDate);
                    var validationResult = importation.Validate();
                    if (validationResult.IsValid)
                    {
                        newImportations.Add(importation);
                    }
                    else {
                        _validationErrors.AddRange(
                            validationResult.Errors.Select(x => new ValidationError($"Row {i}", x.ErrorMessage)));
                    }
                }                
            }
            if (!this.IsValid())
            {
                return null;
            }

            var result = _unitOfWork.GetImportationRepository().InsertList(newImportations);
            _unitOfWork.Commit();
            return result.Select(x => (ImportationResponseDto)x);
        }

        public bool IsValid()
        {
            return !_validationErrors.Any();
        }
    }
}