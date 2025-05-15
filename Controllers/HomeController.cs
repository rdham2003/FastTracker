using System.Diagnostics;
using FastTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Job> jobs = new List<Job>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            Job newJob = new Job(rand.Next(0, 99999999), job, position, url, Status.APPLIED, date.ToString("MM-dd-yyyy"));
            jobs.Add(newJob);
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
                    break;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
