using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FastTracker.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; } // This must exist
        public string Name { get; set; }
        public string Position { get; set; }
        public string PicId { get; set; }
        public Status Status { get; set; }
        public DateTime DateUpdated { get; set; }

        public Job() { }

        public Job(int id, string name, string position, string picId, Status status, DateTime dateUpdated)
        {
            Id = id;
            Name = name;
            Position = position;
            PicId = picId;
            Status = status;
            DateUpdated = dateUpdated;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id &&
                   Name == job.Name &&
                   Position == job.Position &&
                   PicId == job.PicId &&
                   Status == job.Status &&
                   DateUpdated == job.DateUpdated;
        }
    }
}
