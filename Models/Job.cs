namespace FastTracker.Models
{
    public class Job
    {
        private string id { get; set; }
        private string name { get; set; }
        private string pic_id { get; set; }
        private Status status { get; set; }
        private DateOnly dateUpdated { get; set; }

        public Job(string id, string name, string pic_id, Status status, DateOnly dateUpdated)
        {
            this.id = id;
            this.name = name;
            this.pic_id = pic_id;
            this.status = status;
            this.dateUpdated = dateUpdated;
        }
    }
}
