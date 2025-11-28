using Xunit;
using BioLogic;

namespace BioLogic.Tests
{
    public class DnaProcessorTests
    {
        [Fact]
        public void CalculateGcContent_ShouldReturnCorrectPercentage()
        {
            // Arrange
            string dna = "GCGCA"; // 80% of the chars are G or C (4/5), so the result should be 0.8

            // Act
            double result = DnaProcessor.CalculateGcContent(dna);

            // Assert
            Assert.Equal(0.8, result);
        }

        [Fact]
        public void Transcribe_ShouldChangeTtoU()
        {
            // Arrange
            string dna = "GATTACA";

            // Act
            string rna = DnaProcessor.Transcribe(dna);

            // Assert
            Assert.Equal("GAUUACA", rna);
        }
    }
}