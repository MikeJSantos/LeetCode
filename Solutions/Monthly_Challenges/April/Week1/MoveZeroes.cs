namespace LeetCode
{
    public class MoveZeroes
    {
        public void Run(int[] nums)
        {
            if (nums.Length <= 1)
                return;

            var lastIndex = nums.Length - 1;

            for (var i = lastIndex - 1; i >= 0; i--)
            {
                if (nums[i] == 0)
                {
                    for (int j = i; j < lastIndex; j++)
                    {
                        nums[j] = nums[j + 1];
                    }

                    nums[lastIndex] = 0;
                    lastIndex--;
                }
            }
        }
    }
}