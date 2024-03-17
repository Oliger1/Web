using System.ComponentModel.DataAnnotations;

namespace WebOliger.Models
{
    public class AdminRole
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Role UserRole { get; set; }
    }

    public enum Role
    {
        Admin,
        User
    }
}

