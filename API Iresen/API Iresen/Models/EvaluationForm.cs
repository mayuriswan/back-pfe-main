using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace API_Iresen.Models
{
    public class EvaluationForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Step> Steps { get; set; }
    }
}
