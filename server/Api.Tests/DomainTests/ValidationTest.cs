using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.DomainTests
{
    public class Validation : IClassFixture<ImportationFixture>
    {
        [Fact(DisplayName="Name is required test")]
        public async Task RequiredNameValidationTest()
        {
            await Task.Run(() => {
                // arrange
                var nullNameImportation = ImportationFixture.NullNameImportation;

                // act
                var validationResult = nullNameImportation.Validate();
                var nameProperty = validationResult.Errors.FirstOrDefault(x => x.PropertyName == "Name");
                // arrange
                Assert.NotNull(nameProperty);
                Assert.Equal("NotNullValidator", nameProperty.ErrorCode);
            });
        }

        [Fact(DisplayName="Valid importation test")]
        public async Task ValidImportationTest()
        {
            await Task.Run(() => {
                // arrange
                var validImportation = ImportationFixture.ValidImportation;

                // act
                var validationResult = validImportation.Validate();

                // assert
                Assert.True(validationResult.IsValid);
                Assert.Empty(validationResult.Errors);
            });
        }

        [Fact(DisplayName="Importation delivery date invalid")]
        public async Task InvalidDeliveryDateTest()
        {
            await Task.Run(() => {
                // arrange
                var invalidDateImportation = ImportationFixture.InvalidDateImportation;

                // act
                var validationResult = invalidDateImportation.Validate();
                var propertyName = validationResult.Errors.FirstOrDefault(x => x.PropertyName == "DeliveryDate");

                // assert
                Assert.False(validationResult.IsValid);
                Assert.True(validationResult.Errors.Count() == 1);
                Assert.NotNull(propertyName);
            });
        }

        [Fact(DisplayName="Importation quantity invalid")]
        public async Task InvalidQuantityTest()
        {
            await Task.Run(() => {
                // arrange
                var invalidQuantityImportation = ImportationFixture.InvalidQuantityImportation;

                // act
                var validationResult = invalidQuantityImportation.Validate();
                var propertyName = validationResult.Errors.FirstOrDefault(x => x.PropertyName == "Quantity");

                // assert
                Assert.False(validationResult.IsValid);
                Assert.True(validationResult.Errors.Count() == 1);
                Assert.NotNull(propertyName);
            });
        }

        [Fact(DisplayName="Importation unit value invalid")]
        public async Task InvalidUnitValueTest()
        {
            await Task.Run(() => {
                // arrange
                var invalidUnitValueImportation = ImportationFixture.InvalidUnitValueImportation;

                // act
                var validationResult = invalidUnitValueImportation.Validate();
                var propertyName = validationResult.Errors.FirstOrDefault(x => x.PropertyName == "UnitValue");

                // assert
                Assert.False(validationResult.IsValid);
                Assert.True(validationResult.Errors.Count() == 1);
                Assert.NotNull(propertyName);
            });
        }
    }
}