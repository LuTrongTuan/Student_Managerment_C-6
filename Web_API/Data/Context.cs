using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_API.Entities;

namespace Web_API.Data
{
    public class Context:IdentityDbContext<IdentityUser>
    {
        public Context(DbContextOptions<Context> options):base(options) {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Key
            builder.Entity<Student>().HasKey(c => c.StudentId);
            builder.Entity<School>().HasKey(c => c.SchoolId);
            builder.Entity<Grade>().HasKey(c => c.GradeId);
            builder.Entity<Majors>().HasKey(c => c.MajorId);
            builder.Entity<Subject>().HasKey(c => c.SubjectId);

            //Student
            builder.Entity<Student>().Property(c => c.Address).HasColumnName("Address").HasMaxLength(500);
            builder.Entity<Student>().Property(c => c.Name).HasColumnName("Name").HasMaxLength(50);
            builder.Entity<Student>().Property(c => c.Gender).HasColumnName("Gender").HasMaxLength(5);
            builder.Entity<Student>().Property(c => c.Phone).HasColumnName("Phone").HasMaxLength(15);
            builder.Entity<Student>().Property(c => c.Email).HasColumnName("Email").HasMaxLength(100);
            builder.Entity<Student>().Property(c => c.Address).HasColumnName("Address").HasMaxLength(500);
            //School
            builder.Entity<School>().Property(c => c.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            //Grade
            builder.Entity<Grade>().Property(c=>c.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            //Majors
            builder.Entity<Majors>().Property(c => c.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            //Subject
            builder.Entity<Subject>().Property(c => c.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            //Subject
            builder.Entity<Subject>().Property(c => c.Summary).HasColumnName("Summary");

            //Foreign key
            builder.Entity<Majors>().HasOne<School>(c => c.School).WithMany(c => c.Major).HasForeignKey(c => c.SchoolId);
            builder.Entity<Grade>().HasOne<School>(c => c.School).WithMany(c => c.Grade).HasForeignKey(c => c.SchoolId);
            builder.Entity<Subject>().HasOne<School>(c => c.School).WithMany(c => c.Subject).HasForeignKey(c => c.SchoolId);




            builder.Entity<Student>().HasOne<Grade>(c => c.Grade).WithMany(c => c.Student).HasForeignKey(c => c.GradeId);
            builder.Entity<Student>().HasOne<Majors>(c => c.Major).WithMany(c => c.Student).HasForeignKey(c => c.MajorId);

            builder.Entity<StudentSubject>().HasOne<Student>(c => c.Student).WithMany(c => c.StudentSubject)
                .HasForeignKey(c => c.StudentId);


            builder.Entity<StudentSubject>().HasOne<Subject>(c => c.Subject).WithMany(c => c.StudentSubject)
                .HasForeignKey(c => c.SubjectId);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
    }
}