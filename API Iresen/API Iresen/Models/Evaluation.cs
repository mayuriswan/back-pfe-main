namespace API_Iresen.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BaseDeNotation { get; set; }
       
        public ICollection<EvaluationCriterion> Criteria { get; set; } = new List<EvaluationCriterion>();



    }
}
     