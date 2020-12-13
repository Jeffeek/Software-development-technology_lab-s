using System;
using System.Collections.Generic;
using System.Text;

namespace TRPO_CYK
{
    public class CYK
    {
        public List<Rule> Rules { get; }
        public string InitialString { get; }
        public int RulesCount { get; }
        public char StartSymbol { get; }
        public bool ParseResult { get; private set; }
        public int InitialLength { get; } 

        private bool[,,] _resultMatrix;

        public CYK(string initialString, List<Rule> rules, char startSymbol = 'S')
        {
            InitialString = initialString;
            InitialLength = InitialString.Length;
            Rules = rules;
            RulesCount = Rules.Count;
            StartSymbol = startSymbol;
            _resultMatrix = new bool[InitialLength, InitialLength, RulesCount];
        }

        public void Parse()
        {
            InitTable();

            for (int i = 1; i < InitialLength; i++)
            {
                for (int j = 0; j < InitialLength - i; j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        ParseRules(j, k, i);
                    }
                }
            }

            SetResult();
        }

        private void ParseRules(int j, int k, int i)
        {
            for (int x = 0; x < RulesCount; x++)
            {
                for (int y = 0; y < RulesCount; y++)
                {
                    if (_resultMatrix[j, k, x] &&
                        _resultMatrix[j + k + 1, i - k - 1, y])
                    {
                        for (int z = 0; z < RulesCount; z++)
                        {
                            if (Rules[z].Validate(Rules[x], Rules[y]))
                            {
                                _resultMatrix[j, i, z] = true;
                            }
                        }
                    }
                }
            }
        }

        public string GetResultAsString()
        {
            var sb = new StringBuilder();
            for (int i = InitialLength - 1; i >= 0; i--)
            {
                for (int j = 0; j < InitialLength; j++)
                {
                    sb.Append('|');

                    for (int z = 0; z < RulesCount; z++)
                    {
                        if (_resultMatrix[j, i, z])
                            sb.Append(Rules[z].RuleSymbol);
                        else
                            sb.Append(' ');
                    }
                    if (j == InitialLength - 1)
                        sb.Append('|');
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private void SetResult()
        {
            for (int i = 0; i < RulesCount; i++)
            {
                if (_resultMatrix[0, InitialLength - 1, i] &&
                    Rules[i].RuleSymbol == StartSymbol)
                {
                    ParseResult = true;
                    break;
                }
            }
        }

        private void InitTable()
        {
            for (int i = 0; i < InitialLength; i++)
            {
                for (int j = 0; j < RulesCount; j++)
                {
                    if (Rules[j].Validate(InitialString[i]))
                    {
                        _resultMatrix[i, 0, j] = true;
                    }
                }
            }
        }
    }
}
