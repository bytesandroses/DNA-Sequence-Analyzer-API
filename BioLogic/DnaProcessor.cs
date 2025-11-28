namespace BioLogic
{
    public static class DnaProcessor
    {
        public static double CalculateGcContent(string sequence)
        {
            if (string.IsNullOrEmpty(sequence)) return 0.0;

            var upperSeq = sequence.ToUpper();
            double gcCount = upperSeq.Count(c => c == 'G' || c == 'C');

            return gcCount / upperSeq.Length;
        }

        public static string Transcribe(string sequence)
        {
            if (string.IsNullOrEmpty(sequence)) return string.Empty;

            return sequence.ToUpper().Replace('T', 'U');
        }
    }
}