using System.Collections.Generic;

namespace brackets
{
    public class BracketsValidator
    {
        public static bool IsValid(string codeBlock)
        {
            var usedOpeners = new Stack<char>();

            foreach (var character in codeBlock)
            {
                if (Openers.Contains(character))
                {
                    usedOpeners.Push(character);
                }
                else if (Closers.Contains(character))
                {
                    if (usedOpeners.Count == 0) return false;
                    var previousOpener = usedOpeners.Pop();
                    // Does this closer correspond to the latest used opener
                    if (Openers.IndexOf(previousOpener) != Closers.IndexOf(character)) return false;
                }
                    
            }
            return usedOpeners.Count == 0;
        }

        private static readonly List<char> Openers = new List<char> {'(', '{', '['};
        private static readonly List<char> Closers = new List<char> {')', '}', ']'};
    }
}