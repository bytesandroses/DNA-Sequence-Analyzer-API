namespace BioLogic
{
    public static class DnaValidator
    {

        private const string ValidNucleotides = "ATCG";

        public static bool IsValid(string sequence)
        {
            if (string.IsNullOrEmpty(sequence)) return false;

            var upperSeq = sequence.ToUpper();

            // Check if every character is A, T, C, or G
            return upperSeq.All(c => ValidNucleotides.Contains(c));
        }
    }
}