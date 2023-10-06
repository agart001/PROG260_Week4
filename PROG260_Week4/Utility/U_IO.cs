using System.IO;

namespace PROG260_Week4.Utility
{

    /// <summary>
    /// Utility class for Input/Output (I/O) operations, providing methods to manipulate files and directories.
    /// </summary>
    public static class U_IO
    {
        /// <summary>
        /// Represents a DirectoryInfo instance pointing to the usable base directory
        /// of the current application. The directory is resolved by invoking the
        /// BaseDir() method.
        /// </summary>
        public static DirectoryInfo UseableBaseDir = new DirectoryInfo(BaseDir());

        /// <summary>
        /// Retrieves the base directory of the current application, resolving the full path
        /// by navigating upwards from the application's base directory.
        /// </summary>
        /// <returns>The full path of the resolved base directory.</returns>
        public static string BaseDir()
        {
            // Combine the current application's base directory with a relative path
            // to navigate upwards and resolve the full path.
            string str = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

            // Return the resolved base directory path.
            return str;
        }

        /// <summary>
        /// Represents a dictionary mapping file extensions to their respective delimiters.
        /// The keys are file extensions (e.g., ".csv"), and the values are the delimiter characters.
        /// </summary>
        public static Dictionary<string, char> DelimiterDict = new Dictionary<string, char>()
        {
            { ".csv", ',' },
            { ".txt", '|' }
        };

        /// <summary>
        /// Reads the contents of a file specified by the given path and returns the content as a string.
        /// If an exception occurs during the file reading process, the error message is printed to the console.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The contents of the file as a string, or an empty string if an error occurs.</returns>
        public static string GetFileContents(string path)
        {
            // Initialize an empty string to store file contents.
            string fileContents = string.Empty;

            try
            {
                // Attempt to read the contents of the file and assign it to the variable.
                fileContents = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                // Handle exceptions by printing the error message to the console.
                Console.WriteLine(ex.Message);
            }

            // Return the contents of the file, or an empty string if an error occurred.
            return fileContents;
        }

        /// <summary>
        /// Creates a DirectoryInfo object for the specified path and returns it.
        /// If an exception occurs during the creation process, the error message is printed to the console.
        /// </summary>
        /// <param name="path">The path for which to create a DirectoryInfo object.</param>
        /// <returns>A DirectoryInfo object representing the specified path, or null if an error occurs.</returns>
        public static DirectoryInfo? GetDirectoryInfo(string path)
        {
            // Initialize a DirectoryInfo object to null.
            DirectoryInfo dir = null;

            try
            {
                // Attempt to create a DirectoryInfo object for the specified path.
                dir = new DirectoryInfo(path);
            }
            catch (Exception ex)
            {
                // Handle exceptions by printing the error message to the console.
                Console.WriteLine(ex.Message);
            }

            // Return the DirectoryInfo object for the specified path, or null if an error occurred.
            return dir;
        }

        /// <summary>
        /// Clears the content of the output file associated with the given IFile object.
        /// If the output file does not exist, no action is taken.
        /// </summary>
        /// <param name="file">The IFile object representing the file for which to clear the output.</param>
        public static void ClearOutputFile(IFile file)
        {
            // Build the path for the output file based on the provided IFile object.
            string output = $"{file.Dir}\\{file.Name}_.out.txt";

            // Check if the output file exists; if not, no action is taken.
            if (File.Exists(output) == false) 
            {
                return;
            }

            // Delete the output file.
            File.Delete(output);
        }

        /// <summary>
        /// Outputs the content of the input file, processed and formatted, to an output file.
        /// The output file is created in the same directory as the input file with the name "{file.Name}_.out.txt".
        /// Each line in the output file contains the line number and the fields of the corresponding line from the input file.
        /// </summary>
        /// <param name="file">The IFile object representing the input file to be processed and written to the output file.</param>
        public static void OutputToFile(IFile file)
        {
            // Create a FileStream and a StreamWriter for the output file.
            FileStream stream = new FileStream($"{file.Dir}\\{file.Name}_.out.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            // Use a StreamReader to read the content of the input file.
            using (StreamReader reader = new StreamReader(file.AbsPath))
            {
                int lineCount = 1;
                var line = reader.ReadLine();

                // Process each line in the input file.
                while (line != null)
                {
                    // Construct the output line with line number and field details.
                    string output = $"Line #{lineCount}: ";
                    var fields = line.Split(file.Delimiter);

                    int fieldCount = 1;
                    foreach (var field in fields)
                    {
                        if (fieldCount != 1) 
                        {
                            output += " ==> ";
                        }
                        
                        output += $"Field #{fieldCount}={field}";
                        fieldCount++;
                    }

                    // Write the formatted output line to the output file.
                    writer.WriteLine(output);

                    lineCount++;
                    line = reader.ReadLine();
                }
            }

            // Close the StreamWriter and FileStream to ensure proper resource cleanup.
            writer.Close();
            stream.Close();
        }

    }
}