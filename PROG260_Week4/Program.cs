using static PROG260_Week4.Utility.U_IO;
using static PROG260_Week4.Utility.U_Console;

/// <summary>
/// All comments were generated using ChatGPT3
/// using a text document to as shell to copy paste.
/// I used to following format when generating them:
/// 
/// generate code clarity comments for this c# { --- }:
///     
///     -
///     -
///     -
///     
/// 
/// ChatGPT3 url: https://chat.openai.com/
/// </summary>
namespace PROG260_Week4
{
    /// <summary>
    /// Main program class for executing file manipulation operations.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the program.</param>
        static void Main(string[] args)
        {
            // Clear the console for a clean display.
            Console.Clear();

            // Get the DirectoryInfo object for the sample directory.
            DirectoryInfo SampleDir = GetDirectoryInfo($"{UseableBaseDir}\\Samples");

            // Create a list to store IFile objects representing files in the sample directory.
            List<IFile> files = new List<IFile>();

            // Iterate through each file in the sample directory and add an InputFile object to the list.
            foreach (FileInfo file in SampleDir.GetFiles())
            {
                files.Add(new InputFile(file.FullName, file.Name, file.Extension, GetFileContents(file.FullName)));
            }

            // Clear the content of the output file for each file in the list.
            files.ForEach(file => ClearOutputFile(file));

            // Write processed content to the output file for each file in the list.
            files.ForEach(file => OutputToFile(file));

            // Print a message indicating the completion of the operations.
            Print("All done!");
        }
    }
}