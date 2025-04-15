using System;
using System.IO;
using DotNetEnv;
using static System.Net.WebRequestMethods;

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
                    if (i == 0)
                    {
                        continue;
                    }
                    string[] job = lines[i].Split(',');
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
