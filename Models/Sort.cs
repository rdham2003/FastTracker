using System;
using Microsoft.IdentityModel.Tokens;

namespace FastTracker.Models
{
    public class Sort
    {
        public static List<Job> sortJobs(List<Job> jobs, string orgMethod)
        {
            if (jobs.Count < 2) {  return jobs; }
            bool isRev = orgMethod.Substring(orgMethod.Length - 3).Equals("Rev") ? true : false;
            string sortMethod = isRev ? orgMethod.Substring(0, orgMethod.Length - 3) : orgMethod;

            List<Job> sortedJobs;
            switch (sortMethod)
            {
                case "date":
                    sortedJobs = sortByDate(jobs);
                    break;
                case "status":
                    sortedJobs = sortByStatus(jobs);
                    break;
                case "alpha":
                    sortedJobs = sortByAlpha(jobs);
                    break;
                default:
                    sortedJobs = null;
                    break;
            }

            if (isRev && !sortedJobs.IsNullOrEmpty())
            {
                sortedJobs.Reverse();
            }

            return sortedJobs;
        }

        static List<Job> sortByAlpha(List<Job> jobs)
        {
            jobs.Sort((a, b) => string.Compare(a.Name, b.Name));
            return jobs;
        }

        static List<Job> sortByStatus(List<Job> jobs)
        {
            List<Status> statusList = new List<Status>();
            statusList.Add(Status.ACCEPTED);
            statusList.Add(Status.OFFER);
            statusList.Add(Status.INTERVIEW);
            statusList.Add(Status.PHONE_SCREEN);
            statusList.Add(Status.OA);
            statusList.Add(Status.APPLIED);
            statusList.Add(Status.WAITLISTED);
            statusList.Add(Status.REJECTED);
            statusList.Add(Status.UNKNOWN);

            List<Job> sortedJobs = new List<Job>();

            foreach (Status status in statusList)
            {
                foreach (Job job in jobs)
                {
                    if (job.Status == status)
                    {
                        sortedJobs.Add(job);
                    }
                }
                jobs.RemoveAll(job => job.Status == status);
            }

            return sortedJobs;
        }

        static List<Job> sortByDate(List<Job> jobs)
        {
            jobs.Sort((a, b) => ((DateTimeOffset)a.DateUpdated).ToUnixTimeSeconds().CompareTo(((DateTimeOffset)b.DateUpdated).ToUnixTimeSeconds()));
            return jobs;
        }
    }
}
