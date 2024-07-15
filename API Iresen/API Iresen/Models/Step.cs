namespace API_Iresen.Models
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FormField> Fields { get; set; }
        public int EvaluationFormId { get; set; }
    }
}

