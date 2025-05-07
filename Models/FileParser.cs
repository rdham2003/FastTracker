using DotNetEnv;

namespace FastTracker.Models
{
    public class FileParser
    {
        public string filename { get; set; }

        public FileParser(string filename)
        {
            this.filename = filename;
            Env.Load();

        }
        public List<Job> ParseSheetForJobs()
        {
            try
            {

                var jobs = new List<Job>();
                string apiKey = Environment.GetEnvironmentVariable("LogoApiKey");

                var lines = System.IO.File.ReadAllLines(filename);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] job = lines[i].Split(',');
                    if (job.Length != 4)
                    {
                        return null;
                    }
                    if (i == 0 && job[0] != "Company" && job[1] != "Title" && job[2] != "Status" && job[3] != "Date")
                    {
                        return null;
                    }
                    if (i == 0)
                    {
                        continue;
                    }
                    string url = $@"https://img.logo.dev/{job[0]}.com?token={apiKey}";
                    if (Enum.TryParse(job[2].ToUpper(), out Status status))
                    {
                        jobs.Add(new Job(i, job[0], job[1], url, status, job[3]));
                    }
                    else
                    {
                        jobs.Add(new Job(i, job[0], job[1], url, Status.UNKNOWN, job[3]));
                    }
                }
                return jobs;
            }
            catch (Exception e) {
                return null;
            }
        }
    }
}
