using System.ComponentModel.DataAnnotations;

namespace ProjektDotNet.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } =new
            List<User>();
    }
}
