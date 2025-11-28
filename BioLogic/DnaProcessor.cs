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

        public static string ReverseComplement(string sequence)
        {
            if (string.IsNullOrEmpty(sequence)) return string.Empty;

            var upperSeq = sequence.ToUpper();
            
            char[] nucleotides = upperSeq.ToCharArray();
            
            Array.Reverse(nucleotides);

            for (int i = 0; i < nucleotides.Length; i++)
            {
                nucleotides[i] = nucleotides[i] switch
                {
                    'A' => 'T',
                    'T' => 'A',
                    'C' => 'G',
                    'G' => 'C',
                    _ => nucleotides[i] // Keep foreign characters unchanged
                };
            }

            return new string(nucleotides);
        }
    }
}