using BioLogic; // Import your Phase 1 library

namespace BioSharpApi.Services
{
    public class DnaService : IDnaService
    {
        public bool ValidateSequence(string sequence)
        {
            return DnaValidator.IsValid(sequence);
        }

        public string Transcribe(string sequence)
        {
            return DnaProcessor.Transcribe(sequence);
        }

        public string GetReverseComplement(string sequence)
        {
            return DnaProcessor.ReverseComplement(sequence);
        }

        public double GetGcContent(string sequence)
        {
            return DnaProcessor.CalculateGcContent(sequence);
        }
    }
}