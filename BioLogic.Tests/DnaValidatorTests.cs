using Xunit;
using BioLogic;

namespace BioLogic.Tests
{
    public class DnaValidatorTests
    {
        [Theory] 
        [InlineData("A")]           // Single char
        [InlineData("GATTACA")]     // Standard
        [InlineData("gattaca")]     // Lowercase (Your logic handles this)
        [InlineData("GaTtAcA")]     // Mixed case
        public void IsValid_ShouldReturnTrue_ForValidSequences(string sequence)
        {
            // Act
            bool result = DnaValidator.IsValid(sequence);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Z")]           // Invalid char
        [InlineData("GAT TACA")]    // Space in middle
        [InlineData("123")]         // Numbers
        [InlineData("!@#")]         // Symbols
        [InlineData("")]            // Empty string
        [InlineData(null)]          // Null
        public void IsValid_ShouldReturnFalse_ForInvalidSequences(string sequence)
        {
            // Act
            bool result = DnaValidator.IsValid(sequence);

            // Assert
            Assert.False(result);
        }
    }
}