namespace API_Iresen.Models
{
    public class Champ
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public List<string> Choices { get; set; } = new List<string>();
    }
}
