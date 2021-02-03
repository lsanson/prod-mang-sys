using System;
using Api.Domain.Entities;

namespace Api.Tests.DomainTests
{
    public class ImportationFixture
    {
        public static Importation ValidImportation { get; set; }
        public static Importation InvalidDateImportation { get; set; }
        public static Importation InvalidQuantityImportation { get; set; }
        public static Importation InvalidUnitValueImportation { get; set; }
        public static Importation NullNameImportation { get; set; }

        public ImportationFixture()
        {
            ValidImportation = new Importation(
                "Product x", 23, (decimal)10.9, DateTime.Today.AddDays(5)
            );
            InvalidDateImportation = new Importation(
                "Product y", 9, (decimal)2.7, DateTime.Today.AddDays(-1)
            );
            InvalidQuantityImportation = new Importation(
                "Product z", -1, (decimal)8.1, DateTime.Today.AddDays(5)
            );
            InvalidUnitValueImportation = new Importation(
                "Product a", 8, (decimal)-0.3, DateTime.Today.AddDays(5)
            );
            NullNameImportation = new Importation(
                null, 3, (decimal)9.9, DateTime.Today.AddDays(5)
            );
        }
    }
}