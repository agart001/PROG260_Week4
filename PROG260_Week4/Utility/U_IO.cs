using System.IO;

namespace PROG260_Week4.Utility
{
    public static class U_IO
    {
        public static DirectoryInfo UseableBaseDir = new DirectoryInfo(BaseDir());

        public static string BaseDir()
        {
            string str = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

            return str;
        }

        public static Dictionary<string, char> DelimiterDict = new Dictionary<string, char>()
        {
            {".csv", ','},
            {".txt", '|'}
        };

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

        public static DirectoryInfo? GetDirectoryInfo(string path)
        {
            DirectoryInfo dir = null;
            try
            {
                dir = new DirectoryInfo(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dir;
        }

        public static void ClearOutputFile(IFile file)
        {
            string output = $"{file.Dir}\\{file.Name}_.out.txt";
            if(!File.Exists(output)) return;

            File.Delete($"{file.Dir}\\{file.Name}_.out.txt");
        }

        public static void OutputToFile(IFile file)
        {
            FileStream stream = new FileStream($"{file.Dir}\\{file.Name}_.out.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            using (StreamReader reader = new StreamReader(file.AbsPath))
            {
                int lineCount = 1;
                var line = reader.ReadLine();

                while(line != null)
                {
                    string output = $"Line #{lineCount}: ";
                    var fields = line.Split(file.Delimiter);

                    int fieldCount = 1;
                    foreach (var field in fields)
                    {
                        if(fieldCount != fields.Length) output += " ==> ";
                        output += $"Field #{fieldCount}={field}";
                        fieldCount++;
                    }

                    writer.WriteLine(output);

                    lineCount++;
                    line = reader.ReadLine();
                }
            }

            writer.Close();
            stream.Close();
        }
    }
}