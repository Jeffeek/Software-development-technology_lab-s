namespace TRPO_CYK
{
    public class Rule
    {
        public char RuleSymbol { get; set; }
        private string _ruleString;

        public Rule(char ruleSymbol, string n)
        {
            RuleSymbol = ruleSymbol;
            _ruleString = n;
        }

        public bool Validate(char c)
        {
            for (int i = 0; i < _ruleString.Length; i++)
                if (c == _ruleString[i])
                    return true;
            return false;
        }

        public bool Validate(Rule X, Rule Y)
        {
            if (_ruleString[0] == X.RuleSymbol && _ruleString[1] == Y.RuleSymbol)
                return true;
            return false;
        }
    }
}
