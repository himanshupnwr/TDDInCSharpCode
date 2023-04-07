using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCode
{
    //Symbol - I, V, X,  L,   C,   D,   M
    //value  - 1, 5, 10, 50, 100, 500, 1000
    public class RomanNumerals
    {
        private static readonly Dictionary<char, int> map = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public static int Parse(string romanNumerals)
        {
            int result = 0;
            for (int i = 0; i < romanNumerals.Length; i++)
            {
                if (i + 1 < romanNumerals.Length && IsSubtractive(romanNumerals[i], romanNumerals[i + 1]))
                {
                    result -= map[romanNumerals[i]];
                }
                else
                {
                    result += map[romanNumerals[i]];
                }
            }

            return result;
        }

        private static bool IsSubtractive(char v1, char v2)
        {
            return map[v1] < map[v2];
        }
    }
}
