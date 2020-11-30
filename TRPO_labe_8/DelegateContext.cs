using System;

namespace TRPO_labe_8
{
    class DelegateContext
    {
        public T TestDelegate<T>(Delegat<T> delegat, params T[] args)
        {
            return delegat(args);
        }

        public T TestFuncDelegate<T>(Func<T[], T> action, params T[] args)
        {
            return action(args);
        }
    }
}
