namespace TRPO_CYK
{
    public class Rule
    {
        public char CharRule { get; }
        private string _ruleString;

        public Rule(char charRule, string ruleString)
        {
            CharRule = charRule;
            _ruleString = ruleString;
        }

        public bool Check(char ruleChar) => _ruleString.Contains(ruleChar);

        public bool Check(Rule X, Rule Y) =>
            _ruleString[0] == X.CharRule &&
            _ruleString[1] == Y.CharRule;
    }
}
