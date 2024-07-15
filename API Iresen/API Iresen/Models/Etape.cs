using System;

namespace API_Iresen.Models
{
    public class Etape
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Champ> Champs { get; set; } = new List<Champ>();
    }
}
