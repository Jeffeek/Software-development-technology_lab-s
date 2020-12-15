using System;
using System.Collections.Generic;
using System.Text;

namespace TRPO_CYK
{
    public class CYK
    {
        public List<Rule> Rules { get; }
        public char StartSymbol { get; }
        public int InitialStringLength { get; private set; }
        public int RulesCount { get; }

        private bool _finalResult;
        private bool[,,] _matrix;
        private string _initialString;

        public CYK(List<Rule> rules, char startSymbol = 'S')
        {
            Rules = rules;
            RulesCount = Rules.Count;
            StartSymbol = startSymbol;
        }

        public bool Parse(string initialString)
        {
            _initialString = initialString;
            InitialStringLength = _initialString.Length;
            _matrix = new bool[InitialStringLength,InitialStringLength,RulesCount];
            InitTable();

            for (int i = 1; i < InitialStringLength; i++)
            {
                for (int j = 0; j < InitialStringLength - i; j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        ParseRules(j, k, i);
                    }
                }
            }

            SetResult();
            return _finalResult;
        }

        private void ParseRules(int j, int k, int i)
        {
            for (int x = 0; x < RulesCount; x++)
            {
                for (int y = 0; y < RulesCount; y++)
                {
                    if (_matrix[j, k, x] &&
                        _matrix[j + k + 1, i - k - 1, y])
                    {
                        for (int t = 0; t < RulesCount; t++)
                        {
                            if (Rules[t].Check(Rules[x], Rules[y]))
                                _matrix[j, i, t] = true;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < InitialStringLength; i++)
            {
                for (int j = 0; j < InitialStringLength; j++)
                {
                    sb.Append('|');

                    for (int z = 0; z < RulesCount; z++)
                    {
                        if (_matrix[j, i, z])
                            sb.Append(Rules[z].CharRule);
                        else
                            sb.Append('.');
                    }
                    if (j == InitialStringLength - 1)
                        sb.Append('|');
                }
                sb.AppendLine();
            }
            sb.AppendLine();
            return sb.ToString();
        }

        private void SetResult()
        {
            for (int i = 0; i < RulesCount; i++)
            {
                if (_matrix[0, InitialStringLength - 1, i] &&
                    Rules[i].CharRule == StartSymbol)
                {
                    _finalResult = true;
                    break;
                }
            }

        }

        private void InitTable()
        {
            for (int i = 0; i < InitialStringLength; i++)
            {
                for (int j = 0; j < RulesCount; j++)
                {
                    if (Rules[j].Check(_initialString[i]))
                        _matrix[i, 0, j] = true;
                }
            }
        }
    }
}
