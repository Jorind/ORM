using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scaffolding.Models
{
    public partial class DishContext : DbContext
    {
        public DishContext()
        {
        }

        public DishContext(DbContextOptions<DishContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Dishes;Trusted_Connection=1;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasIndex(e => e.DishId, "IX_Ingredients_DishId");

                entity.Property(e => e.Amount).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UnitOfMeasure).HasMaxLength(50);

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.DishId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
