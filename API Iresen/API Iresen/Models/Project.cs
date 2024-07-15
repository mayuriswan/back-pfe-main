using System;
using System.Collections.Generic;

namespace API_Iresen.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public string? Category { get; set; } = "";
        public int? ResponsiblePersonId { get; set; }
        public int? HostingInstitutionId { get; set; }
        public Hostinginstitution? HostingInstitution { get; set; }
        public int? Budget { get; set; } = 0;
        public int? MinDuration { get; set; } = 1;
        public int? MaxDuration { get; set; } = 2;
        public int? TaskTypeId { get; set; }
        public Tasktype? TaskType { get; set; }
        public bool? SeparateBudget { get; set; } = false;
        public int? PostBudget { get; set; } = 0;
        public List<string>? AuthorizedCountries { get; set; } = new List<string>();
        public DateOnly? PublicationDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public DateOnly? ClosingDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        public int? AcceptedSubmissions { get; set; } = 1;
        public int? EvaluationFormId { get; set; }
        public EvaluationForm? EvaluationForm { get; set; }
        public string? DocumentPath { get; set; }
        public string? PhotoPath { get; set; }
        public bool? IsDraft { get; set; } = false;
        public int? EvaluationId { get; set; }
        public Evaluation? Evaluation { get; set; }
        public bool? IsPublic { get; set; } = false;
        public int? NombreSubmissions { get; set; } = 0; 
        public List<Submission>? Submissions { get; set; } = new List<Submission>();
        public List<int>? Evaluators { get; set; } = new List<int>();

        public void UpdateIsPublic()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            IsPublic = today >= PublicationDate && today <= ClosingDate;
        }
    }
}
