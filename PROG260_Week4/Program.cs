using static PROG260_Week4.Utility.U_IO;
using static PROG260_Week4.Utility.U_Console;

namespace PROG260_Week4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            DirectoryInfo SampleDir = GetDirectoryInfo($"{UseableBaseDir}\\Samples");

            List<IFile> files = new List<IFile>();

            foreach (FileInfo file in SampleDir.GetFiles())
            {
                files.Add(new InputFile(file.FullName, file.Name, file.Extension, GetFileContents(file.FullName)));
            }

            files.ForEach(file => ClearOutputFile(file));

            files.ForEach(file => OutputToFile(file));

            Print("All done!");
        }
    }
}