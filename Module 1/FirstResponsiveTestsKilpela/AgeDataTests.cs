using FirstResponsiveWebAppKilpela.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FirstResponsiveTestsKilpela
{
    public class AgeDataTests
    {
        // First test for lowest age
        [Fact]
        public void AgeThisYearLowestAgePossibleTest()
        {
            // Arrange
            var ageData = new AgeData { birthYear = 2025 };

            // Act
            var age = ageData.AgeThisYear();

            // Assert
            Assert.Equal(0, age); 

        }

        // Test for highest age possible 
        [Fact]
        public void AgeThisYearHighestPossibleAgeTest()
        {
            // Arrange
            var ageData = new AgeData { birthYear = 1925 };

            //Act 
            var age = ageData.AgeThisYear();

            // Assert 
            Assert.Equal(100, age);
        }

        // Test for if it is calculating it correctly 
        [Fact]

        public void AgeThisYearFrom1998Test()
        {
            // Arrange
            var ageData = new AgeData { birthYear = 1998 };

            // Act 
            var age = ageData.AgeThisYear();

            // Assert
            Assert.Equal(27, age);
        }

        // Testing if the required varaibles are in the program

        [Fact]
        public void AllValuesArePresentTest()
        {
            // Arrange 
            var ageData = new AgeData { Name = "Donovan", birthYear = 1998 };
            var context = new ValidationContext(ageData);

            // Act 
            bool isValid = Validator.TryValidateObject(ageData, context, null, true);

            // Assert 
            Assert.True(isValid);
        }

        // Test for if name is not provided 
        [Fact]
        public void NameIsNotPresentTest()
        {
            // Arrange
            var ageData = new AgeData { Name = "", birthYear = 1998 };
            var context = new ValidationContext(ageData);

            // Act 
            bool isValid = Validator.TryValidateObject(ageData, context, null, true);

            // Assert 
            Assert.False(isValid);
        }

        // Test if the birthYear is out of range
        [Fact]
        public void BirthYearOutOfRangeTest()
        {
            // Arrange
            var ageData = new AgeData { Name = "Donovan", birthYear = 1900};
            var context = new ValidationContext(ageData);

            // Act
            bool isValid = Validator.TryValidateObject(ageData, context, null, true);

            // Assert
            Assert.False(isValid);
        }

        // Test for if the birthYear is not provided
        [Fact]
        public void NoBirthYearTest()
        {
            // Arrange 
            var ageData = new AgeData { Name = "Donovan" };
            var context = new ValidationContext(ageData);

            // Act 
            bool isValid = Validator.TryValidateObject(ageData, context, null, true);

            // Assert 
            Assert.False(isValid);
        }




    }
}