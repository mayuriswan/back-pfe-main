namespace API_Iresen.Models
{
    public class EvaluationNote
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public Submission? Submission { get; set; }
        public int EvaluatorId { get; set; }
        public User? Evaluator { get; set; }
        public List<EvaluationNoteCriterion> CriteriaNotes { get; set; } = new List<EvaluationNoteCriterion>();
        public int BaseNote { get; set; }
        public int GlobalNote { get; set; }
        public string Comments { get; set; }
    }
}
