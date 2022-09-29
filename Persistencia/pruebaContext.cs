
using System;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Persistencia
{
    public partial class pruebaContext : DbContext
    {
        public pruebaContext()
        {
        }

        public pruebaContext(DbContextOptions<pruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cedulado> Cedulados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-VJH4EMM\\SQLEXPRESS;Database=prueba;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cedulado>(entity =>
            {
                entity.HasKey(e => e.NumeroCedula);

                entity.ToTable("Cedulado");

                entity.Property(e => e.NumeroCedula)
                    .ValueGeneratedNever()
                    .HasColumnName("Numero_Cedula");

                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.FechaNacimineto)
                    .HasMaxLength(50)
                    .HasColumnName("Fecha_Nacimineto");

                entity.Property(e => e.FkCedula).HasColumnName("FK_Cedula");

                entity.Property(e => e.Nacionalidad).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
