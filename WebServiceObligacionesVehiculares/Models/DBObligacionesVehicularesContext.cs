using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebServiceObligacionesVehiculares.Models
{
    public partial class DBObligacionesVehicularesContext : DbContext
    {
        public DBObligacionesVehicularesContext()
        {
        }

        public DBObligacionesVehicularesContext(DbContextOptions<DBObligacionesVehicularesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Multum> Multa { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<PermisoCirculacion> PermisoCirculacions { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DBObligacionesVehiculares; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("Modelo");

                entity.Property(e => e.Modelo1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modelo");
            });

            modelBuilder.Entity<Multum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Multa)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("Fk_IdMulta_Vehiculo");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("Pago");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("Fk_IdPago_Vehiculo");
            });

            modelBuilder.Entity<PermisoCirculacion>(entity =>
            {
                entity.ToTable("PermisoCirculacion");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.PermisoCirculacions)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_IdModelo");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");

                entity.Property(e => e.Patente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_IdModelo_Vehiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
