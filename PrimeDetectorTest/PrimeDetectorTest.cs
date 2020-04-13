using System;
using Xunit;
using PrimeDetector;
using Moq;
using System.Collections.Generic;

namespace PrimeDetectorTest
{
    public class PrimeDetectorTest
    {
        [Fact]
        public void Test_If_It_Can_Detect_A_Non_Prime_Number()
        {

            // Arrange
            var positiveDetectorMock = new Mock<PositiveDetector>();
            var primeDetector = new PrimeDetectorModel(positiveDetectorMock.Object);
            positiveDetectorMock.Setup(pd => pd.IsNumberPositive(29)).Returns(true);

            // Act
            var isPrime = primeDetector.IsPrime(29);

            // Assert
            Assert.Equal(isPrime, true);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(19)]
        [InlineData(23)]
        public void Test_If_It_Can_Detect_Non_Prime_Numbers(int n)
        {
            // Arrange
            var positiveDetectorMock = new Mock<PositiveDetector>();
            var primeDetector = new PrimeDetectorModel(positiveDetectorMock.Object);
            positiveDetectorMock.Setup(pd => pd.IsNumberPositive(n)).Returns(true);

            // Act
            var isPrime = primeDetector.IsPrime(n);

            // Assert
            Assert.Equal(isPrime, true);
        }


        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new PersonModel { Id = 5, Name = "Saadnoor" } };
            yield return new object[] { new PersonModel { Id = 7, Name = "Salehin" } };
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Test_If_It_Can_Detect_Person_Has_Prime_Id_Or_Not(PersonModel person)
        {

            // Arrange
            var positiveDetectorMock = new Mock<PositiveDetector>();
            var primeDetector = new PrimeDetectorModel(positiveDetectorMock.Object);
            positiveDetectorMock.Setup(pd => pd.IsNumberPositive(person.Id)).Returns(true);

            // Act
            var hasPrimeId = primeDetector.HasPrimeId(person);

            // Assert
            Assert.Equal(hasPrimeId, true);
        }
    }
}
