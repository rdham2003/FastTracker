using NUnit.Framework;
using FastTracker.Models;

namespace FastTracker.Tests
{
    public class SortTest
    {
        [Test]
        public void testSortAlpha()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/06/24")));
            jobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/24")));
            jobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));

            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            expectedJobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/06/24")));
            expectedJobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/24")));

            List<Job> sortedJobs = Sort.sortJobs(jobs, "alpha");

            Assert.AreEqual(expectedJobs, sortedJobs);
        }

        [Test]
        public void testSortAlphaReversed()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/06/24")));
            jobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/24")));
            jobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));

            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/24")));
            expectedJobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/06/24")));
            expectedJobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            List<Job> sortedJobs = Sort.sortJobs(jobs, "alphaRev");

            Assert.AreEqual(expectedJobs, sortedJobs);
        }

        [Test]
        public void testSortDate()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/25")));
            jobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            jobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/12/24")));
           

            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/12/24")));
            expectedJobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/25")));
            expectedJobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));

            List<Job> sortedJobs = Sort.sortJobs(jobs, "date");

            Assert.AreEqual(expectedJobs, sortedJobs);
        }

        [Test]
        public void testSortDateReversed()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/25")));
            jobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            jobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/12/24")));


            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            expectedJobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/25")));
            expectedJobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/12/24")));

            List<Job> sortedJobs = Sort.sortJobs(jobs, "dateRev");

            Assert.AreEqual(expectedJobs, sortedJobs);
        }

        [Test]
        public void testSortStatus()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            jobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/12/24")));
            jobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/25")));


            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            expectedJobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/25")));
            expectedJobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/12/24")));

            List<Job> sortedJobs = Sort.sortJobs(jobs, "status");

            Assert.AreEqual(expectedJobs, sortedJobs);
        }

        [Test]
        public void testSortStatusReversed()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            jobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/12/24")));
            jobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/25")));


            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(1, "Google", "SWE Intern", @"https://img.logo.dev/Google.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.APPLIED, DateTime.Parse("12/12/24")));
            expectedJobs.Add(new Job(2, "Meta", "SWE Intern", @"https://img.logo.dev/Meta.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.OA, DateTime.Parse("12/08/25")));
            expectedJobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));

            List<Job> sortedJobs = Sort.sortJobs(jobs, "statusRev");

            Assert.AreEqual(expectedJobs, sortedJobs);
        }

        [Test]
        public void testEmptyJobList()
        {
            List<Job> jobs = new List<Job>();
            List<Job> expectedJobs = new List<Job>();

            List<Job> sortedJobs = Sort.sortJobs(jobs, "status");

            Assert.AreEqual(expectedJobs, sortedJobs);
        }

        [Test]
        public void testJobListOne()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));

            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(3, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));

            List<Job> sortedJobs = Sort.sortJobs(jobs, "status");

            Assert.AreEqual(expectedJobs, sortedJobs);
        }

        [Test]

        public void testJobListSameStatus()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(1, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            jobs.Add(new Job(2, "Cisco", "SWE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            jobs.Add(new Job(3, "Noblis", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));

            List<Job> expectedJobs = new List<Job>();
            expectedJobs.Add(new Job(1, "Amazon", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            expectedJobs.Add(new Job(2, "Cisco", "SWE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));
            expectedJobs.Add(new Job(3, "Noblis", "SDE Intern", @"https://img.logo.dev/Amazon.com?token=pk_QddZ213bQvSYsdFEpzoztw", Status.INTERVIEW, DateTime.Parse("1/25/26")));

            List<Job> sortedJobs = Sort.sortJobs(jobs, "status");

            Assert.AreEqual(expectedJobs, sortedJobs);
        }
    }
}
