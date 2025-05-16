using NUnit.Framework;
using FastTracker.Models;
using DotNetEnv;

namespace FastTracker.Tests
{
    public class FileParserTestdotnet
    {
        [Test]
        public void TestFileParserFileNotFound()
        {
            FileParser fileparser = new FileParser("C:\\Users\\rohit\\OneDrive\\Desktop\\FastTracker\\Tests\\Interships 2025 tracking.csv");
            List<Job> jobs = fileparser.ParseSheetForJobs();

            Assert.AreEqual(null, jobs);
        }

        [Test]
        public void TestFileParser()
        {
            FileParser fileparser = new FileParser("C:\\Users\\rohit\\OneDrive\\Desktop\\FastTracker\\Tests\\tracker.csv");
            List<Job> jobs = fileparser.ParseSheetForJobs();

            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/06/24")));
            expectedJobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/24")));
            expectedJobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));

            for (int i = 0; i < jobs.Count; i++)
            {
                Assert.IsTrue(jobs[i].Equals(expectedJobs[i]));
            }
        }

        [Test]
        public void TestEmptyFileParser()
        {
            FileParser fileparser = new FileParser("C:\\Users\\rohit\\OneDrive\\Desktop\\FastTracker\\Tests\\emptyTracker.csv");
            List<Job> jobs = fileparser.ParseSheetForJobs();

            Assert.IsEmpty(jobs);
        }

        [Test]
        public void TestUnrecognizedStatuses()
        {
            FileParser fileparser = new FileParser("C:\\Users\\rohit\\OneDrive\\Desktop\\FastTracker\\Tests\\UnknownStatus.csv");
            List<Job> jobs = fileparser.ParseSheetForJobs();

            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/06/24")));
            expectedJobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/24")));
            expectedJobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.UNKNOWN, DateTime.Parse("1/25/26")));

            for (int i = 0; i < jobs.Count; i++)
            {
                Assert.IsTrue(jobs[i].Equals(expectedJobs[i]));
            }
        }

        [Test]
        public void testBadFile()
        {
            FileParser fileparser = new FileParser("C:\\Users\\rohit\\OneDrive\\Desktop\\FastTracker\\Tests\\badfile.csv");
            List<Job> jobs = fileparser.ParseSheetForJobs();

            Assert.IsNull(jobs);
        }
    }
}
