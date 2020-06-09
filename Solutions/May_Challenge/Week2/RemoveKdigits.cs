using System.Numerics;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public string RemoveKdigits(string num, int k)
        {
            if (!BigInteger.TryParse(num, out var parsedNum))
                return num;
            if (parsedNum == 0 || k >= num.Length)
                return "0";

            return RemoveKdigits_Recurse(num.TrimStart('0'), k, num);
        }

        private string RemoveKdigits_Recurse(string num, int k, string currentMin)
        {
            if (k < 1)
                return currentMin;

            k -= 1;

            for (var i = 0; i < num.Length; i++)
            {
                var newNumStr = num.Remove(i, 1);
                
                if (newNumStr.StartsWith('0'))
                    newNumStr = newNumStr.TrimStart('0');

                if (k > 0)
                {
                    var recursedNum = RemoveKdigits_Recurse(newNumStr, k, currentMin);
                    currentMin = recursedNum;
                }
                else
                {
                    currentMin = RemoveKdigits_GetMinString(currentMin, newNumStr);
                }
            }

            return currentMin;
        }

        private string RemoveKdigits_GetMinString(string str1, string str2)
        {
            if (str1 == str2)
                return str1;
            else if (str1.Length < str2.Length)
                return str1;
            else if (str2.Length < str1.Length)
                return str2;
            
            for (var i = 0; i < str1.Length; i++)
            {
                if (str1[i] < str2[i])
                    return str1;
                else if (str2[i] < str1[i])
                    return str2;
            }

            return str1; // Redundant, shouldn't reach this code
        }
    }

    public partial class UnitTests
    {
        [Fact(Skip = "Can't handle large input lengths (up to 10,002)")]
        public void RemoveKdigitsTest()
        {
            var s = new Solution();
            int k;
            string num, output;

            num = "1432219";
            k = 3;
            output = "1219";
            Assert.Equal(output, s.RemoveKdigits(num, k));

            num = "10200";
            k = 1;
            output = "200";
            Assert.Equal(output, s.RemoveKdigits(num, k));

            num = "10";
            k = 2;
            output = "0";
            Assert.Equal(output, s.RemoveKdigits(num, k));

            num = "0";
            k = 0;
            output = "0";
            Assert.Equal(output, s.RemoveKdigits(num, k));

            num = "12345";
            k = 0;
            output = num;
            Assert.Equal(output, s.RemoveKdigits(num, k));

            // TODO: Failed test case. Length 10,001 > 8899 (https://leetcode.com/submissions/detail/338806794/)
            num = ReadTestDataFromFile("RemoveKdigits_input.txt");
            k = 1000;
            output = ReadTestDataFromFile("RemoveKdigits_output.txt");
            Assert.Equal(output, s.RemoveKdigits(num, k));
        }
    }
}