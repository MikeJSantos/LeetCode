using System.IO;

namespace LeetCode
{
    public partial class UnitTests
    {
        private string ReadTestDataFromFile(string fileName)
        {
            var basePath = Directory.GetCurrentDirectory();

            var path = Path.Combine(basePath, "TestData", fileName);
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}