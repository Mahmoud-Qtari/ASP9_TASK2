using System.ComponentModel.DataAnnotations;

namespace TASK2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }=false;
    }
}
