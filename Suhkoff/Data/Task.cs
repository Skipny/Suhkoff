using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Suhkoff.Data
{
    public class tasks
    {
        [Key]
        public int task_id {get;set;}
        public string task_name { get;set;}
        public string? task_description {get;set;}
        public string task_status {get;set;}
        public DateTime dateTime { get;set;}
        [ForeignKey("user_id")]
        public virtual users users { get; set; }
        //public int? user_id { get; set; }
        //public users users{ get; set; }
    }
}
