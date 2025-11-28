namespace BioSharpApi.Services
{
    public interface IDnaService
    {
        bool ValidateSequence(string sequence);
        string Transcribe(string sequence);
        string GetReverseComplement(string sequence);
        double GetGcContent(string sequence);
    }
}