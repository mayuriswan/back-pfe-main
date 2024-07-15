namespace API_Iresen.Models
{
    public class EvaluationCriterion
    {
        public int Id { get; set; }
        public string Criterion { get; set; }
        public int Note { get; set; }
        public int EvaluationId { get; set; }
        public Evaluation? Evaluation { get; set; }
    }
}
