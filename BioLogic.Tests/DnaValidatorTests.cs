using Xunit;
using BioLogic;

namespace BioLogic.Tests
{
    public class DnaValidatorTests
    {
        [Fact]
        public void IsValidDna_ShouldReturnTrue_ForValidSequence()
        {
            // Arrange
            string validSequence = "GATTACA";

            // Act
            bool result = DnaValidator.IsValid(validSequence);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidDna_ShouldReturnFalse_ForInvalidSequence()
        {
            // Arrange
            string invalidSequence = "GATTACA-Z";

            // Act
            bool result = DnaValidator.IsValid(invalidSequence);

            // Assert
            Assert.False(result);
        }
    }
}