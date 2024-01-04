using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IndividuelltDatabasProjektTess.Models;

public partial class SchoolLabb2Context : DbContext
{
    public SchoolLabb2Context()
    {
    }

    public SchoolLabb2Context(DbContextOptions<SchoolLabb2Context> options)
        : base(options)
    {
    }
    public DbSet<StudentInfoDto> StudentInfo { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseTeacher> CourseTeachers { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<GradeDetail> GradeDetails { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffProfession> StaffProfessions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolLabb2;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D718771DF0D23");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseDescription).HasMaxLength(150);
            entity.Property(e => e.CourseName).HasMaxLength(50);
        });

        modelBuilder.Entity<CourseTeacher>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Course_Teacher");

            entity.Property(e => e.FkCourseId).HasColumnName("FK_CourseID");
            entity.Property(e => e.FkTeacherId).HasColumnName("FK_TeacherID");

            entity.HasOne(d => d.FkCourse).WithMany()
                .HasForeignKey(d => d.FkCourseId)
                .HasConstraintName("Course_Teacher_CourseID");

            entity.HasOne(d => d.FkTeacher).WithMany()
                .HasForeignKey(d => d.FkTeacherId)
                .HasConstraintName("Course_Teacher_TeacherID");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F6877FBFB58BF90");

            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.FkCourseId).HasColumnName("FK_CourseID");
            entity.Property(e => e.FkGradeId).HasColumnName("FK_GradeID");
            entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentID");
            entity.Property(e => e.StartDate).HasColumnName("StartDate");
            entity.Property(e => e.StopDate).HasColumnName("StopDate");
            entity.Property(e => e.GradeDate).HasColumnName("GradeDate");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");


            entity.HasOne(d => d.FkCourse).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkCourseId)
                .HasConstraintName("FK_CourseID_Enrollment");

            entity.HasOne(d => d.FkGrade).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkGradeId)
                .HasConstraintName("FK_Grade_Enrollment");

            entity.HasOne(d => d.FkStudent).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkStudentId)
                .HasConstraintName("FK_StudentID_Enrollment");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grade__54F87A376D86FD1F");

            entity.ToTable("Grade");

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentID");
            entity.Property(e => e.Grade1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Grade");

            entity.HasOne(d => d.FkStudent).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkStudentId)
                .HasConstraintName("Grade_StudentID");
        });

        modelBuilder.Entity<GradeDetail>(entity =>
        {
            entity.HasKey(e => e.GradeDetailId).HasName("PK__GradeDet__41C6FC3E00E90548");

            entity.Property(e => e.GradeDetailId).HasColumnName("GradeDetailID");
            entity.Property(e => e.FkCourseId).HasColumnName("FK_CourseID");
            entity.Property(e => e.FkGradeId).HasColumnName("FK_GradeID");
            entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentID");
            entity.Property(e => e.SetDate).HasColumnType("date");

            entity.HasOne(d => d.FkCourse).WithMany(p => p.GradeDetails)
                .HasForeignKey(d => d.FkCourseId)
                .HasConstraintName("GradeDetails_FK_CourseID");

            entity.HasOne(d => d.FkGrade).WithMany(p => p.GradeDetails)
                .HasForeignKey(d => d.FkGradeId)
                .HasConstraintName("GradeDetails_FK_Grade");

            entity.HasOne(d => d.FkStudent).WithMany(p => p.GradeDetails)
                .HasForeignKey(d => d.FkStudentId)
                .HasConstraintName("GradeDetails_StudentID");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.ProfessionId).HasName("PK__Professi__3F309E1FDEF2711E");

            entity.Property(e => e.ProfessionId).HasColumnName("ProfessionID");
            entity.Property(e => e.StaffRole).HasMaxLength(50);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF7F9A0A89C");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.HireDate).HasColumnType("date");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ProfessionId).HasColumnName("ProfessionID");
        });

        modelBuilder.Entity<StaffProfession>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Staff_Professions");

            entity.Property(e => e.FkProfessionId).HasColumnName("FK_ProfessionID");
            entity.Property(e => e.FkStaffId).HasColumnName("FK_StaffID");

            entity.HasOne(d => d.FkProfession).WithMany()
                .HasForeignKey(d => d.FkProfessionId)
                .HasConstraintName("FK_Staff_Professions_ProfessionID");

            entity.HasOne(d => d.FkStaff).WithMany()
                .HasForeignKey(d => d.FkStaffId)
                .HasConstraintName("FK_Staff_Professions_StaffID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A7945231921");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Class).HasMaxLength(5);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<StudentInfoDto>(entity =>
        {
            // Map the properties to columns returned by the stored procedure
            entity.Property(e => e.StudentID).HasColumnName("StudentID");
            entity.Property(e => e.SocialSecurityNumber).HasColumnName("SocialSecurityNumber");
            entity.Property(e => e.Class).HasColumnName("Class");
            entity.Property(e => e.FirstName).HasColumnName("FirstName");
            entity.Property(e => e.LastName).HasColumnName("LastName");
        });

        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<StudentInfoDto>().HasNoKey();

    }
    public void SetGrade(int studentId, int courseId, string grade)
    {
        Database.ExecuteSqlRaw("EXEC SetGrade @p0, @p1, @p2", studentId, courseId, grade);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
