using System.IO;

namespace LeetCode
{
    public partial class UnitTests
    {
        private string ReadTestDataFromFile(string fileName)
        {
            var basePath = @"C:\Projects\Portfolio-dotNet\LeetCode\TestData";

            var path = Path.Combine(basePath, fileName);
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}