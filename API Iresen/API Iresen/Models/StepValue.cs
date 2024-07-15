using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Iresen.Models
{
    public class StepValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubmissionId { get; set; }
        public Submission? Submission { get; set; }
        public List<FormFieldValue> Fields { get; set; } = new List<FormFieldValue>();
    }
}
