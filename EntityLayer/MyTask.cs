using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityLayer;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer
{
    public class MyTask
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        public String TaskName { get; set; }
        public DateTime DeadLine { get; set; }
        public bool TaskStatus { get; set; }
        public String Id { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
