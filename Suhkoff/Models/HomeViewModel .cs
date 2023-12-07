using Suhkoff.Data;

namespace Suhkoff.Models
{
    public class HomeViewModel
    {
        public users? user { get; set; }
        public List<users> Users { get; set; }
        public tasks? task { get; set; }
        public List<tasks> Tasks { get; set; }
    }
}