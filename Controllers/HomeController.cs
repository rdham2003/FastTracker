using System.Diagnostics;
using FastTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace FastTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Job> jobs = new List<Job>();
        private readonly JobDBContext _context;

        public HomeController(ILogger<HomeController> logger, JobDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(jobs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult AddJob(String job, String position)
        {
            string apiKey = Environment.GetEnvironmentVariable("LogoApiKey");
            Random rand = new Random();
            string url = $@"https://img.logo.dev/{job}.com?token={apiKey}";
            DateTime date = DateTime.Now;
            Job newJob = new Job(rand.Next(0, 99999999), job, position, url, Status.APPLIED, date);
            jobs.Add(newJob);
            _context.Jobs.Add(newJob); 
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditJob(int id, string status)
        {
            foreach(var job in jobs)
            {
                if (job.Id == id)
                {
                    job.Status = Enum.TryParse(status.ToUpper(), out Status newStat) ? newStat : Status.UNKNOWN;
                    var jobInDb = _context.Jobs.FirstOrDefault(j => j.Id == id);
                    if (jobInDb != null)
                    {
                        jobInDb.Status = Enum.TryParse(status.ToUpper(), out Status newStatus) ? newStat : Status.UNKNOWN;

                        _context.SaveChanges();
                    }

                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteJob(int id)
        {
            foreach (var job in jobs)
            {
                if (job.Id == id)
                {
                    jobs.Remove(job);
                    _context.Jobs.Remove(job);
                    _context.SaveChanges();
                    break;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SortJobs(string sortBy)
        {
            jobs = Sort.sortJobs(jobs, sortBy);
            return RedirectToAction("Index");
        }
    }
}
