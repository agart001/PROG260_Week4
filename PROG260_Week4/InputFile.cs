using static PROG260_Week4.Utility.U_IO;

namespace PROG260_Week4
{
    /// <summary>
    /// Represents an input file, implementing the IFile interface.
    /// </summary>
    public class InputFile : IFile
    {
        /// <summary>
        /// Gets or sets the absolute path of the input file.
        /// </summary>
        public string AbsPath { get; set; }

        /// <summary>
        /// Gets or sets the directory of the input file.
        /// </summary>
        public string Dir { get; set; }

        /// <summary>
        /// Gets or sets the name of the input file (excluding extension).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the extension of the input file.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the delimiter used in the input file.
        /// </summary>
        public char Delimiter { get; set; }

        /// <summary>
        /// Gets or sets the contents of the input file.
        /// </summary>
        public string FileContents { get; set; }

        /// <summary>
        /// Default constructor for InputFile.
        /// </summary>
        public InputFile()
        {
            // Default constructor intentionally left empty.
        }

        /// <summary>
        /// Parameterized constructor for InputFile, initializing properties based on provided values.
        /// </summary>
        /// <param name="absPath">The absolute path of the input file.</param>
        /// <param name="name">The name of the input file (including extension).</param>
        /// <param name="extension">The extension of the input file.</param>
        /// <param name="fileContents">The contents of the input file.</param>
        public InputFile(string absPath, string name, string extension, string fileContents)
        {
            // Set properties based on provided values.
            AbsPath = absPath;
            Dir = AbsPath.Substring(0, AbsPath.LastIndexOf('\\'));

            Name = name.Substring(0, name.LastIndexOf('.'));
            Extension = extension;
            Delimiter = DelimiterDict[Extension];

            FileContents = fileContents;
        }
    }
}