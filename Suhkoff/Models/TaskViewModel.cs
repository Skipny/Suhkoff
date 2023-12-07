namespace Suhkoff.Models
{
    public class TaskViewModel
    {
        public int id { get; set; }
        public string task_name { get; set; }
        public string task_description { get; set; }
        public string task_status { get; set; }
        public int user_id { get; set; }
    }
}
