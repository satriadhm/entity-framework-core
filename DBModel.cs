using System.ComponentModel.DataAnnotations;

namespace CSharpImplementation
{
    public class DBModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(255)]
        public string Info { get; set; }
    }
}
