namespace API_Iresen.Models
{
    public class FormFieldValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Options { get; set; }
        public string? Value { get; set; }
        public int StepValueId { get; set; }
        public StepValue? StepValue { get; set; }
    }
}
