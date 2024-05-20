using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungKiemTraTracNghiem.EntityLayer.Data;

namespace UngDungKiemTraTracNghiem.DataAccessLayer.Context
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DoAn_KTTN;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailUserAndExam>().HasKey(sc => new { sc.UserID, sc.ExamID });

            modelBuilder.Entity<DetailUserAndExam>()
               .HasOne<User>(s => s.User)
               .WithMany(g => g.DetailUserAndExams)
               .HasForeignKey(s => s.UserID);

            modelBuilder.Entity<DetailUserAndExam>()
                .HasOne<Exam>(s => s.Exam)
                .WithMany(g => g.DetailUserAndExams)
                .HasForeignKey(s => s.ExamID);

            modelBuilder.Entity<DetailExamAndQuestion>().HasKey(sc => new { sc.ExamID, sc.QuestionID });

            modelBuilder.Entity<DetailExamAndQuestion>()
              .HasOne<Exam>(s => s.Exam)
              .WithMany(g => g.DetailExamAndQuestions)
              .HasForeignKey(s => s.ExamID);

            modelBuilder.Entity<DetailExamAndQuestion>()
              .HasOne<Question>(s => s.Question)
              .WithMany(g => g.DetailExamAndQuestions)
              .HasForeignKey(s => s.QuestionID);

            modelBuilder.Entity<Exam>()
            .HasOne<Category>(s => s.Category)
            .WithMany(g => g.Exams)
            .HasForeignKey(s => s.CategoryID);


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Category>categories { get; set; }
        public DbSet<Exam>exams { get; set; }
        public DbSet<Question>questions { get; set; }
        public DbSet<DetailExamAndQuestion> DetailExamAndQuestions { get; set; }
        public DbSet<DetailUserAndExam>DetailUserAndExams { get; set; }

    }
}
