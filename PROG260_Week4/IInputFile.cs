namespace PROG260_Week4
{
    public interface IInputFile
    {
        public string AbsPath { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string FileContents { get; set; }
    }
}