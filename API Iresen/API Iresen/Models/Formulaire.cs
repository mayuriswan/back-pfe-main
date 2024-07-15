namespace API_Iresen.Models
{
    public class Formulaire
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Etape> Etapes { get; set; } = new List<Etape>();
    }

}
