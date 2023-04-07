using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCode
{
    //Acharya Pingala created mathematical fibonacci sequence in Maurya period
    //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144,..
    public class FibonacciNumbers
    {
        //Recursion - Time Complexity: Exponential, as every function calls two other functions.
        //Space: O(n) if we consider the function call stack size, otherwise O(1).
        public int GetFibonacci(int index)
        {
            if (index == 0) return 0;
            if (index == 1) return 1;
            return GetFibonacci(index - 1) + GetFibonacci(index - 2);
        }

        //using dynamic programming
        //Time complexity: O(n) for given n
        //Auxiliary space: O(n)
        public int fibDynamic(int n)
        {
            // Declare an array to
            // store Fibonacci numbers.
            // 1 extra to handle
            // case, n = 0
            int[] f = new int[n + 2];
            int i;

            /* 0th and 1st number of the
               series are 0 and 1 */
            f[0] = 0;
            f[1] = 1;

            for (i = 2; i <= n; i++)
            {
                /* Add the previous 2 numbers
                   in the series and store it */
                f[i] = f[i - 1] + f[i - 2];
            }

            return f[n];
        }

        //space optimized method
        //Time Complexity: O(n) 
        //Extra Space: O(1)
        public int FibSpace(int n)
        {
            int a = 0, b = 1, c = 0;

            // To return the first Fibonacci number
            if (n == 0) return a;

            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return b;
        }
    }
}
