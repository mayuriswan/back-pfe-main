namespace API_Iresen.Models
{
    public class EvaluationNoteCriterion
    {
        public int Id { get; set; }
        public int? EvaluationNoteId { get; set; }
        public EvaluationNote? EvaluationNote { get; set; }
        public int CriterionId { get; set; }
        public string CriterionName { get; set; }
        public int BaseDeNotation { get; set; } // This is the base note from EvaluationCriterion
        public int Note { get; set; } // This is the note given by the evaluator
    }
}
