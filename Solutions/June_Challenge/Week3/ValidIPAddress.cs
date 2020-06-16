using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 98.37% of submissions https://leetcode.com/submissions/detail/354464440
        public string ValidIPAddress(string IP)
        {
            if (IP.Contains('.') && ValidIPAddress_IsV4(IP))
                return "IPv4";
            else if (IP.Contains(':') && ValidIPAddress_IsV6(IP))
                return "IPv6";
            else
                return "Neither";
        }

        public bool ValidIPAddress_IsV4(string IP)
        {
            var splitIP = IP.Split('.');

            if (splitIP.Length != 4)
                return false;

            foreach (var num in splitIP)
            {
                if (num == "0")
                    continue;
                else if (num.Any("0-".Contains))
                    return false;
                else if (!int.TryParse(num, out var parsedNum))
                    return false;
                else if (parsedNum < 0 || parsedNum > 255)
                    return false;
            }

            return true;
        }

        public bool ValidIPAddress_IsV6(string IP)
        {
            var splitIP = IP.Split(':');

            if (splitIP.Length != 8)
                return false;

            foreach (var num in splitIP)
            {
                if (num == string.Empty || num.Length > 4)
                    return false;
                else if (!num.All("0123456789abcdefABCDEF".Contains))
                    return false;
            }

            return true;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void ValidIPAddressTest()
        {
            var s = new Solution();
            string IP, expected;

            IP       = "172.16.254.1";
            expected = "IPv4";
            Assert.Equal(expected, s.ValidIPAddress(IP));

            IP       = "2001:0db8:85a3:0:0:8A2E:0370:7334";
            expected = "IPv6";
            Assert.Equal(expected, s.ValidIPAddress(IP));

            IP       = "256.256.256.256";
            expected = "Neither";
            Assert.Equal(expected, s.ValidIPAddress(IP));

            // Test Case 65/79 https://leetcode.com/submissions/detail/354457206
            IP       = "01.01.01.01";
            expected = "Neither";
            Assert.Equal(expected, s.ValidIPAddress(IP));

            // Test Case 74/79 https://leetcode.com/submissions/detail/354458986
            IP       = "00.0.0.0";
            expected = "Neither";
            Assert.Equal(expected, s.ValidIPAddress(IP));

            // Test Case 74/79 https://leetcode.com/submissions/detail/354459746
            IP       = "0.0.0.-0";
            expected = "Neither";
            Assert.Equal(expected, s.ValidIPAddress(IP));

            // Test Case 78/79 https://leetcode.com/submissions/detail/354463682
            IP       = "2001:db8:85a3:0::8a2E:0370:7334";
            expected = "Neither";
            Assert.Equal(expected, s.ValidIPAddress(IP));
        }
    }
}