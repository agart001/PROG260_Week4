using System.IO;

namespace PROG260_Week4.Utility
{
    public static class U_IO
    {
        public static string GetFileContents(string path)
        {
            string fileContents = string.Empty;
            try
            {
                fileContents = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return fileContents;
        }
    }
}