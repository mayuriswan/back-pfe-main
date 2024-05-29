namespace API_Iresen.Models
{
    public class ProjectCall
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Responsable { get; set; }
        public string Categorie { get; set; }
        public string InstitutHote { get; set; }
        public decimal Budget { get; set; }
        public int DureeMinimale { get; set; }
        public int DureeMaximale { get; set; }
        public string TypeTache { get; set; }
        public string PaysAutorises { get; set; }
        public bool BudgetSepare { get; set; }
        public string PostBudget { get; set; }
        public DateTime DatePublication { get; set; }
        public DateTime DateCloture { get; set; }
        public int SoumissionAcceptee { get; set; }
        public string FormulaireEvaluation { get; set; }
        public string Documents { get; set; }
    }
}
