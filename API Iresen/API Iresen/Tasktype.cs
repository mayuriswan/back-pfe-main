using System.ComponentModel.DataAnnotations;

namespace API_Iresen
{
    public class Tasktype
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
    }
}
