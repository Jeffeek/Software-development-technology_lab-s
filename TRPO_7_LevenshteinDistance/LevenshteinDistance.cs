using System;

namespace TRPO_7_LevenshteinDistance
{
    public class LevenshteinDistance
    {
        private string _firstString;
        private string _secondString;

        public LevenshteinDistance(string firstString, string secondString)
        {
            if (firstString == null) throw new ArgumentNullException("string1");
            if (secondString == null) throw new ArgumentNullException("string2");
            _firstString = firstString;
            _secondString = secondString;
        }

        public int CalculateLevenshteinDistance()
        {
            int difference = 0;
            int[,] matrix = new int[_firstString.Length + 1, _secondString.Length + 1];

            for (int i = 0; i <= _firstString.Length; i++) { matrix[i, 0] = i; }
            for (int j = 0; j <= _secondString.Length; j++) { matrix[0, j] = j; }

            for (int i = 1; i <= _firstString.Length; i++)
            {
                for (int j = 1; j <= _secondString.Length; j++)
                {
                    difference = (_firstString[i - 1] == _secondString[j - 1]) ? 0 : 1;
                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, 
                                                     matrix[i, j - 1] + 1), 
                                            matrix[i - 1, j - 1] + difference);
                }
            }
            return matrix[_firstString.Length, _secondString.Length];
        }
    }
}
