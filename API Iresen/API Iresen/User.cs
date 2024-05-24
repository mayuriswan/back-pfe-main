using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Iresen
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Firstname { get; set; }

        [StringLength(20)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }
    }
}