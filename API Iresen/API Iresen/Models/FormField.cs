namespace API_Iresen.Models
{
    public class FormField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Options { get; set; }
        public int StepId { get; set; }
        public string? Value { get; set; } // Add this line
    }
}
