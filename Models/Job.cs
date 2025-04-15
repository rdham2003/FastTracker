using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FastTracker.Models
{
    public class Job
    {
        private int id { get; set; }
        private string name { get; set; }
        private string position { get; set; }
        private string pic_id { get; set; }
        private Status status { get; set; }
        private string dateUpdated { get; set; }

        public Job(int id, string name, string position, string pic_id, Status status, string dateUpdated)
        {
            this.id = id;
            this.name = name;
            this.position = position;
            this.pic_id = pic_id;
            this.status = status;
            this.dateUpdated = dateUpdated;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   id == job.id &&
                   name == job.name &&
                   position == job.position &&
                   pic_id == job.pic_id &&
                   status == job.status &&
                   dateUpdated == job.dateUpdated;
        }
    }
}
