using COAE_PDF_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace COAE_PDF_BACKEND.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<AdvisorProject>()
                .HasOne(advisorProject => advisorProject.Advisor)
                .WithMany(advisor => advisor.Projects)
                .HasForeignKey(advisorProject => advisorProject.AdvisorId);

            builder.Entity<AdvisorProject>()
                .HasOne(advisorProject => advisorProject.Project)
                .WithMany(project => project.RegisteredAdvisors)
                .HasForeignKey(advisorProject => advisorProject.ProjectId);

            builder.Entity<StudentProject>()
                .HasOne(studentProject => studentProject.Student)
                .WithMany(student => student.Projects)
                .HasForeignKey(studentProject => studentProject.StudentId);

            builder.Entity<StudentProject>()
                .HasOne(studentProject => studentProject.Project)
                .WithMany(project => project.RegisteredStudents)
                .HasForeignKey(studentProject => studentProject.ProjectId);

            builder.Entity<FrequencySheet>()
                .HasOne(frequencySheet => frequencySheet.Project)
                .WithMany(project => project.FrequencySheets)
                .HasForeignKey(FrequencySheet => FrequencySheet.ProjectId);

            builder.Entity<Frequency>()
                .HasOne(frequency => frequency.FrequencySheet)
                .WithMany(frequencySheet => frequencySheet.Frequencies)
                .HasForeignKey(frequencySheet => frequencySheet.FrequencySheetId);
        }
        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<FrequencySheet> FrequencySheets{ get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<AdvisorProject> AdvisorProjects { get; set; }
        public DbSet<StudentProject> StudentProjects { get; set; }
    }
}
