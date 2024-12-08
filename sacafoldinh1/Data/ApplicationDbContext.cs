
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sacafoldinh1.Models;
using System.Reflection.Emit;

namespace sacafoldinh1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> Answers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            


            base.OnModelCreating(modelBuilder);
            //علاقة بين Course و ApplicationUser CreatedBy
            modelBuilder.Entity<Enrollment>()
              .HasKey(e => new { e.UserId, e.CourseId });

            modelBuilder.Entity<Course>()
                 .HasOne(c => c.CreatedBy)
                 .WithMany()
                 .HasForeignKey(c => c.CreatedById)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
              .HasOne(e => e.User)
              .WithMany()
              .HasForeignKey(e => e.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Assignments)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Submission>()
               .HasOne(a => a.Assignment)
               .WithMany(c => c.Submissions)
               .HasForeignKey(a => a.AssignmentId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Submission>()
               .HasOne(a => a.User)
               .WithMany()
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Exam>()
               .HasOne(a => a.Course)
               .WithMany(c => c.Exams)
               .HasForeignKey(a => a.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExamResult>()
               .HasOne(a => a.Exam)
               .WithMany(c => c.ExamResults)
               .HasForeignKey(a => a.ExamId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExamResult>()
               .HasOne(a => a.User)
               .WithMany()
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Question>()
              .HasOne(a => a.Exam)
              .WithMany(c => c.Questions)
              .HasForeignKey(a => a.ExamId)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Answer>()
             .HasOne(a => a.Question)
             .WithMany(c => c.Answers)
             .HasForeignKey(a => a.QuestionId)
             .OnDelete(DeleteBehavior.Restrict);





            modelBuilder.Entity<Lesson>()
              .HasOne(a => a.Module)
              .WithMany(l => l.Lessons)
              .HasForeignKey(a => a.ModuleId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Module>()
              .HasMany(a => a.Lessons)
              .WithOne(l => l.Module)
              .HasForeignKey(a => a.ModuleId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
              .HasMany(a => a.Modules)
              .WithOne(l => l.Course)
              .HasForeignKey(a => a.CourseId)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<IdentityRole>().HasData(

             new IdentityRole()
             {

                 Id = Guid.NewGuid().ToString(),
                 Name = "Admin",
                 NormalizedName = "admin",
                 ConcurrencyStamp = Guid.NewGuid().ToString(),

             },
            new IdentityRole()
            {

                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "user",
                ConcurrencyStamp = Guid.NewGuid().ToString(),

            },
              new IdentityRole()
              {

                  Id = Guid.NewGuid().ToString(),
                  Name = "Teacher",
                  NormalizedName = "teacher",
                  ConcurrencyStamp = Guid.NewGuid().ToString(),

              });

        }
    }
}
