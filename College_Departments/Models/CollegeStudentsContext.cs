using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace College_Departments
{
    public partial class CollegeStudentsContext : DbContext
    {
        public CollegeStudentsContext()
        {
        }

        public CollegeStudentsContext(DbContextOptions<CollegeStudentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CollegeStudent> CollegeStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CollegeStudents");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CollegeStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__College___32C52B9942353646");

                entity.ToTable("College_Students");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.FathersName)
                    .HasMaxLength(50)
                    .HasColumnName("Fathers_Name");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.MothersName)
                    .HasMaxLength(50)
                    .HasColumnName("Mothers_Name");

                entity.Property(e => e.StudentsAge).HasColumnName("Students_Age");

                entity.Property(e => e.StudentsName)
                    .HasMaxLength(50)
                    .HasColumnName("Students_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
