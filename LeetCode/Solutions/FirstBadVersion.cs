using System;
using System.Linq;
using System.Collections.Generic;

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */
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

        private bool IsBadVersion(int version)
        {
            return version >= 1150769282;
        }
    }
}