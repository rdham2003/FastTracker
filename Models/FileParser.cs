namespace FastTracker.Models
{
    public class FileParser
    {
        public string filename { get; set; }

        public FileParser(string filename)
        {
            this.filename = filename;
        }

        public List<int> ParseSheetForJobs(string filename)
        {
            return new List<int> { 1, 2, 3, 4, 5 };
        }
    }
}
