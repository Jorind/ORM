using HelloEF.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HelloEF
{
 public partial class SchoolContext : DbContext
 {
     //Lista e te gjitha modeleve qe dua ti kem si tabela ne Databaze.

    public DbSet<Student> Students { get; set; }
            

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
                      .IsRequired();

                entity.Property(e => e.LastName)
                      .HasColumnName("Surname")
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.Age)
                      .HasColumnName("Age")
                      .IsRequired();
            });
    }
 }
}

