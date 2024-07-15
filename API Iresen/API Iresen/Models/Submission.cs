using System;
using System.Collections.Generic;

namespace API_Iresen.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public List<StepValue> StepValues { get; set; } = new List<StepValue>();
        public List<EvaluationNote>? EvaluationNotes { get; set; } = new List<EvaluationNote>();
    }
}
