using System.ComponentModel.DataAnnotations;

namespace LoginForm.Models
{
    public class User_tbl
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? MobileNo { get; set; }
        [Required]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
