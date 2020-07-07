using System;
using System.Linq;
using System.Collections.Generic;

namespace LeetCode
{
    public partial class Solution 
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var strDict = new Dictionary<string, IList<string>>();

            foreach (var str in strs)
            {
                var sortedStr = String.Concat(str.OrderBy(c => c).ToList());

                if (strDict.ContainsKey(sortedStr))
                {
                    strDict[sortedStr].Add(str);
                }
                else
                {
                    strDict[sortedStr] = new List<string> { str };
                }
            }

            var retVal = strDict.Values.ToList();
            return (retVal as IList<IList<string>>);
        }
    }
}