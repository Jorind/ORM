using HelloEF.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HelloEF
{
 public partial class SchoolContext : DbContext
 {
     //Lista e te gjitha modeleve qe dua ti kem si tabela ne Databaze.
    //(Jo domosdoshmerisht cdo model qe kemi)
    //(Jo domosdoshmerisht cdo tabele e Databazes duhet te jete tek ky Context)

    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Project> Projects { get; set; }


    public SchoolContext (DbContextOptions<SchoolContext> options) :
        base(options) {
            }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{

    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fluent API
        modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                      .HasColumnName("Name")
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.LastName)
                      .HasColumnName("Surname")
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.Age)
                      .HasColumnName("Age")
                      .IsRequired();

                // if we want to turn Address into a shadow property uncomment this and remove this property from the model
                    //entity.Property<string>("Address");

                //Shadow Property means an existing DbColumn that we do not want to deal with from code
                //entity.Property<LevelOfExpertise>("LevelOfExpertise");

                //entity.Ignore(e => e.LevelOfExpertise);

                //entity.Property(e => e.LastUpdate)
                //    .IsRequired()
                //    .IsRowVersion();
                
                entity.HasOne(d => d.Department)
                      .WithMany(p => p.Students)
                      .HasForeignKey(d => d.DepartmentId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Students_Departments");
            });
    
        modelBuilder.Entity<ProjectStudent>().HasKey(e => e.Id);

        modelBuilder.Entity<ProjectStudent>()
            .HasOne(bc => bc.Student)
            .WithMany(b => b.ProjectStudents)
            .HasForeignKey(bc => bc.StudentId);  

        modelBuilder.Entity<ProjectStudent>()
            .HasOne(bc => bc.Project)
            .WithMany(c => c.ProjectStudents)
            .HasForeignKey(bc => bc.ProjectId);   
    }
 }
}

