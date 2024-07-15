using Microsoft.EntityFrameworkCore;
using API_Iresen.Models;

namespace API_Iresen.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Hostinginstitution> Hostinginstitutions { get; set; }
        public DbSet<Tasktype> Tasktypes { get; set; }
        public DbSet<Formulaire> Formulaires { get; set; }
        public DbSet<Etape> Etapes { get; set; }
        public DbSet<Champ> Champs { get; set; }
        public DbSet<EvaluationForm> EvaluationForms { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<StepValue> StepValues { get; set; }
        public DbSet<FormFieldValue> FormFieldValues { get; set; }
        public DbSet<EvaluationCriterion> EvaluationCriteria { get; set; }
        public DbSet<EvaluationNote> EvaluationNotes { get; set; }
        public DbSet<EvaluationNoteCriterion> EvaluationNoteCriteria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<EvaluationForm>()
                .HasMany(e => e.Steps)
                .WithOne()
                .HasForeignKey(s => s.EvaluationFormId);

            modelBuilder.Entity<Step>()
                .HasMany(s => s.Fields)
                .WithOne()
                .HasForeignKey(f => f.StepId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Submissions)
                .WithOne(s => s.Project)
                .HasForeignKey(s => s.ProjectId);

            modelBuilder.Entity<Evaluation>()
                .HasMany(e => e.Criteria)
                .WithOne()
                .HasForeignKey(s => s.EvaluationId);

            modelBuilder.Entity<Submission>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Submission>()
                .HasMany(s => s.StepValues)
                .WithOne(sv => sv.Submission)
                .HasForeignKey(sv => sv.SubmissionId);

            modelBuilder.Entity<StepValue>()
                .HasMany(sv => sv.Fields)
                .WithOne(f => f.StepValue)
                .HasForeignKey(f => f.StepValueId);

            modelBuilder.Entity<EvaluationNote>()
                .HasMany(en => en.CriteriaNotes)
                .WithOne(enc => enc.EvaluationNote)
                .HasForeignKey(enc => enc.EvaluationNoteId);

            modelBuilder.Entity<EvaluationNoteCriterion>()
                .HasOne(enc => enc.EvaluationNote)
                .WithMany(en => en.CriteriaNotes)
                .HasForeignKey(enc => enc.EvaluationNoteId);
        }
    }
}
