using Xunit;
using BioLogic;

namespace BioLogic.Tests
{
    public class DnaProcessorTests
    {
        // GC Content Tests
        [Theory]
        [InlineData("GCGCA", 0.8)]      // Standard (4/5)
        [InlineData("gcgca", 0.8)]      // Lowercase (Should handle it)
        [InlineData("AAAAA", 0.0)]      // 0% GC
        [InlineData("GGGGG", 1.0)]      // 100% GC
        [InlineData("", 0.0)]           // Empty string
        [InlineData(null, 0.0)]         // Null check (Robustness)
        public void CalculateGcContent_ShouldReturnCorrectPercentage(string dna, double expected)
        {
            // Act
            double result = DnaProcessor.CalculateGcContent(dna);

            // Assert
            // Use 2 decimal places to avoid floating point errors
            Assert.Equal(expected, result, precision: 2);
        }

        // Transcription Tests
        [Theory]
        [InlineData("GATTACA", "GAUUACA")]  // Standard
        [InlineData("gattaca", "GAUUACA")]  // Lowercase input -> Uppercase output
        [InlineData("CCGG", "CCGG")]        // No Ts to change
        [InlineData("TTTT", "UUUU")]        // All Ts
        [InlineData("", "")]                // Empty
        public void Transcribe_ShouldReplaceTWithU(string dna, string expected)
        {
            // Act
            string result = DnaProcessor.Transcribe(dna);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}