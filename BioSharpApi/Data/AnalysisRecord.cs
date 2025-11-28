namespace BioSharpApi.Data
{
    public class AnalysisRecord
    {
        public int Id { get; set; } // Primary Key
        public string Sequence { get; set; } = string.Empty;
        public double GcContent { get; set; }
        public string Transcription { get; set; } = string.Empty;
        public string ReverseComplement { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}