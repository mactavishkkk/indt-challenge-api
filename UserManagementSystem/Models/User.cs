using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column("is_admin")]
        public bool IsAdmin { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
