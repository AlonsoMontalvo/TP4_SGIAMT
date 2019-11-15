using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGIAMT_RenovarPago.Models
{
    public partial class BD_SGIAMTvsRenovarPagoContext : DbContext
    {
        public BD_SGIAMTvsRenovarPagoContext()
        {
        }

        public BD_SGIAMTvsRenovarPagoContext(DbContextOptions<BD_SGIAMTvsRenovarPagoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TConceptoPago> TConceptoPago { get; set; }
        public virtual DbSet<TPago> TPago { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2E54QI4\\ALONSO_PC;Database=BD_SGIAMTvsRenovarPago;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TConceptoPago>(entity =>
            {
                entity.HasKey(e => e.PkIcpId);

                entity.ToTable("T_Concepto_Pago");

                entity.Property(e => e.PkIcpId).HasColumnName("PK_ICP_Id");

                entity.Property(e => e.VcpDescripcion)
                    .HasColumnName("VCP_Descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VcpMonto)
                    .HasColumnName("VCP_Monto")
                    .HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<TPago>(entity =>
            {
                entity.HasKey(e => e.PkIpId);

                entity.ToTable("T_Pago");

                entity.Property(e => e.PkIpId).HasColumnName("PK_IP_Id");

                entity.Property(e => e.FkIcpId).HasColumnName("FK_ICP_Id");

                entity.Property(e => e.FkIuDni).HasColumnName("FK_IU_Dni");

                entity.Property(e => e.VpAño).HasColumnName("VP_Año");

                entity.Property(e => e.VpEstado)
                    .HasColumnName("VP_Estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VpFecha)
                    .HasColumnName("VP_Fecha")
                    .HasColumnType("date");

                entity.Property(e => e.VpMes)
                    .HasColumnName("VP_Mes")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VpMonto)
                    .HasColumnName("VP_Monto")
                    .HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.FkIcp)
                    .WithMany(p => p.TPago)
                    .HasForeignKey(d => d.FkIcpId)
                    .HasConstraintName("FK__T_Pago__FK_ICP_I__412EB0B6");

                entity.HasOne(d => d.FkIuDniNavigation)
                    .WithMany(p => p.TPago)
                    .HasForeignKey(d => d.FkIuDni)
                    .HasConstraintName("FK__T_Pago__FK_IU_Dn__403A8C7D");
            });

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.HasKey(e => e.PkIuDni);

                entity.ToTable("T_Usuario");

                entity.Property(e => e.PkIuDni)
                    .HasColumnName("PK_IU_Dni")
                    .ValueGeneratedNever();

                entity.Property(e => e.DuFechaNacimiento)
                    .HasColumnName("DU_FechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.VuAmaterno)
                    .HasColumnName("VU_AMaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuApaterno)
                    .HasColumnName("VU_APaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuCelular).HasColumnName("VU_Celular");

                entity.Property(e => e.VuContraseña)
                    .HasColumnName("VU_Contraseña")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuCorreo)
                    .HasColumnName("VU_Correo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuDireccion)
                    .HasColumnName("VU_Direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuEstado)
                    .HasColumnName("VU_Estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuHorario)
                    .HasColumnName("VU_Horario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuNombre)
                    .HasColumnName("VU_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuSexo)
                    .HasColumnName("VU_Sexo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
