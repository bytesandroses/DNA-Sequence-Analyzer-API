using BioLogic;
using BioSharpApi.Data;

namespace BioSharpApi.Services
{
    public class DnaService : IDnaService
    {
        private readonly BioContext _context;

        public DnaService(BioContext context)
        {
            _context = context;
        }

        public bool ValidateSequence(string sequence) => DnaValidator.IsValid(sequence);
        public string Transcribe(string sequence) => DnaProcessor.Transcribe(sequence);
        public string GetReverseComplement(string sequence) => DnaProcessor.ReverseComplement(sequence);
        public double GetGcContent(string sequence) => DnaProcessor.CalculateGcContent(sequence);
        public async Task<AnalysisRecord> SaveAnalysisAsync(string sequence)
        {
            var record = new AnalysisRecord
            {
                Sequence = sequence,
                Transcription = DnaProcessor.Transcribe(sequence),
                ReverseComplement = DnaProcessor.ReverseComplement(sequence),
                GcContent = DnaProcessor.CalculateGcContent(sequence),
                CreatedAt = DateTime.UtcNow
            };

            _context.AnalysisHistory.Add(record);

            await _context.SaveChangesAsync();

            return record;
        }
    }
}