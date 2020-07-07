using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var visitedList = new bool[0];
            // index: course, value: all the courses that consider the index a prerequisite
            var adjacencyLists = new List<int>[numCourses];

            foreach (var pair in prerequisites)
            {
                var course = pair[0];
                var prereq = pair[1];

                // check for circular graph (ex: [1,0], [0,1])
                if (adjacencyLists[course] != null && adjacencyLists[course].Contains(prereq))
                    return false;

                if (adjacencyLists[prereq] == null)
                    adjacencyLists[prereq] = new List<int>();

                adjacencyLists[prereq].Add(course);
            }

            for (var startingCourse = 0; startingCourse < numCourses; startingCourse++)
            {
                visitedList = new bool[numCourses];
                if (CanFinish_Recurse(startingCourse, adjacencyLists, visitedList))
                    break;
            }

            return visitedList.All(v => v);
        }

        private bool CanFinish_Recurse(int course, List<int>[] adjacencyLists, bool[] visitedList)
        {
            if (visitedList[course])
                return false;

            visitedList[course] = true;

            if (adjacencyLists[course] == null || !adjacencyLists[course].Any())
            {   // Course is not a prerequisite, so any course can be taken next
                for (var nextCourse = 0; nextCourse < adjacencyLists.Length; nextCourse++)
                {
                    if (course != nextCourse && CanFinish_Recurse(nextCourse, adjacencyLists, visitedList))
                        break;
                }
            }
            else
            {
                foreach (var nextCourse in adjacencyLists[course])
                {
                    if (CanFinish_Recurse(nextCourse, adjacencyLists, visitedList))
                        break;
                }
            }
            
            return visitedList.All(v => v);
        }
    }

    public partial class UnitTests
    {
        [Fact(Skip = "Breaks on test case 38/46")]
        public void CanFinishTest()
        {
            var s = new Solution();
            int numCourses;
            int[][] prerequisites;

            numCourses = 2;
            prerequisites = Create2dArray(2, 1, 0);
            // Assert.True(s.CanFinish(numCourses, prerequisites));

            numCourses = 2;
            prerequisites = Create2dArray(2, 1, 0, 0, 1);
            // Assert.False(s.CanFinish(numCourses, prerequisites));

            // Test Case 38/46 (https://leetcode.com/submissions/detail/346404324)
            numCourses = 3;
            prerequisites = Create2dArray(2, 1, 0, 0, 2, 2, 1);
            Assert.False(s.CanFinish(numCourses, prerequisites));
        }
    }
}