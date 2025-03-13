using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektDotNet.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VarChar(50)")]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Bio { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public virtual Posts Group { get; set; }
        public ICollection<Group> Groups { get; set; } = new
            List<Group>();
    }
}
