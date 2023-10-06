namespace PROG260_Week4
{
    /// <summary>
    /// Interface representing a file with essential properties and content information.
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// Gets or sets the absolute path of the file.
        /// </summary>
        string AbsPath { get; set; }

        /// <summary>
        /// Gets or sets the directory of the file.
        /// </summary>
        string Dir { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the extension of the file.
        /// </summary>
        string Extension { get; set; }

        /// <summary>
        /// Gets or sets the delimiter used in the file.
        /// </summary>
        char Delimiter { get; set; }

        /// <summary>
        /// Gets or sets the contents of the file.
        /// </summary>
        string FileContents { get; set; }
    }
}