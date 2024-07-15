using System.ComponentModel.DataAnnotations;

namespace API_Iresen.Models
{
    public class Hostinginstitution
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
    }
}
