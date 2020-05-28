using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int FirstBadVersion(int n)
        {
            var maxVersion = n;
            var minVersion = 1;

            while (minVersion != maxVersion && minVersion != maxVersion - 1)
            {
                var versionDifference = maxVersion - minVersion;
                var versionToCheck = minVersion + (versionDifference / 2);

                if (IsBadVersion(versionToCheck))
                {
                    maxVersion = versionToCheck - 1;
                }
                else
                {
                    minVersion = versionToCheck + 1;
                }
            }

            if (IsBadVersion(minVersion))
                return minVersion;
            else if (minVersion != maxVersion && IsBadVersion(maxVersion))
                return maxVersion;
            else
                return maxVersion + 1;
        }

        /* The isBadVersion API is defined in the parent class VersionControl.
            bool IsBadVersion(int version); */
        private bool IsBadVersion(int version)
        {   // TODO: Mock/fake API call
            return version >= 1150769282;
        }
    }

    public partial class UnitTests
    {
        // [Fact] // Disabled until IsBadVersion() is mocked/faked
        public void FirstBadVersionTest()
        {
            var s = new Solution();

            // Assert.Equal(4, s.FirstBadVersion(5));
            // Assert.Equal(3, s.FirstBadVersion(4));
            // Assert.Equal(1150769282, s.FirstBadVersion(1420736637));
        }
    }
}