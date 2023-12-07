using System.ComponentModel.DataAnnotations;

namespace Suhkoff.Data
{
    public class users
    {
        [Key]
        public int user_id {get;set;}
        public string user_name{get;set;}
        public int age {get;set;}
        public string e_mail{get;set;}
        public string user_password { get; set; }

    }
}
