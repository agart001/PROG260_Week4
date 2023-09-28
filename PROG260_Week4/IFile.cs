namespace PROG260_Week4
{
    public interface IFile
    {
        public string AbsPath { get; set; }
        public string Dir { get; set; }

        public string Name { get; set; }
        public string Extension { get; set; }
        public char Delimiter { get; set; }

        public string FileContents { get; set; }
    }
}