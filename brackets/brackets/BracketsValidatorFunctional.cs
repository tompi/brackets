using System.Collections.Generic;
using System.Linq;

namespace brackets
{
    public static class BracketsValidatorFunctional
    {
        public static bool IsValid(string codeBlock)
        {
            var openersOrClosers = new string(codeBlock
                .Where(Openers.Concat(Closers).Contains)
                .ToArray());

            return HasValidSubScopesOrEmpty(openersOrClosers);
        }

        private static bool HasValidSubScopesOrEmpty(string codeBlock)
        {
            var length = codeBlock.Length;
            // If empty block, its valid
            if (length == 0) return true;
            var codeAfterRemovingInnerScopes = codeBlock
                .Replace("()", "")
                .Replace("{}", "")
                .Replace("[]", "");
            // If we didnt manage to strip anything, the code is not valid
            return codeAfterRemovingInnerScopes.Length != length && 
                   // Check the rest of the string
                   HasValidSubScopesOrEmpty(codeAfterRemovingInnerScopes);
        }

        private static readonly List<char> Openers = new() {'(', '{', '['};
        private static readonly List<char> Closers = new() {')', '}', ']'};
    }
}