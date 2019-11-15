using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGIAMT.Models
{
    public partial class BD_SGIAMTContext : DbContext
    {
        public BD_SGIAMTContext()
        {
        }

        public BD_SGIAMTContext(DbContextOptions<BD_SGIAMTContext> options)
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
                optionsBuilder.UseSqlServer("Server=DESKTOP-HNNEPQ0\\ALONSO_PC;Database=BD_SGIAMTvsregistrarpago;Trusted_Connection=True;");
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

                entity.Property(e => e.VcpValor)
                    .HasColumnName("VCP_Valor")
                    .HasColumnType("decimal(18,0)");
            });

            modelBuilder.Entity<TPago>(entity =>
            {
                entity.HasKey(e => e.PkIpId);

                entity.ToTable("T_Pago");

                entity.Property(e => e.PkIpId).HasColumnName("PK_IP_Id");

                entity.Property(e => e.FkIcpId).HasColumnName("FK_ICP_Id");

                entity.Property(e => e.FkIuDni).HasColumnName("FK_IU_Dni");

                entity.Property(e => e.VpAño).HasColumnName("VP_Año");

                entity.Property(e => e.VpFecha)
                    .HasColumnName("VP_Fecha")
                    .HasColumnType("date");

                entity.Property(e => e.VpMes)
                    .HasColumnName("VP_Mes")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VpPdf)
                    .HasColumnName("VP_Pdf");

                entity.Property(e => e.VpValor)
                    .HasColumnName("VP_Valor")
                    .HasColumnType("decimal(18,0)");

                entity.HasOne(d => d.FkIcp)
                    .WithMany(p => p.TPago)
                    .HasForeignKey(d => d.FkIcpId)
                    .HasConstraintName("FK__T_Pago__FK_ICP_I__3C69FB99");

                entity.HasOne(d => d.FkIuDniNavigation)
                    .WithMany(p => p.TPago)
                    .HasForeignKey(d => d.FkIuDni)
                    .HasConstraintName("FK__T_Pago__FK_IU_Dn__3B75D760");
            });

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.HasKey(e => e.PkIuDni);

                entity.ToTable("T_Usuario");

                entity.Property(e => e.PkIuDni)
                    .HasColumnName("PK_IU_Dni")
                    .ValueGeneratedNever();

                entity.Property(e => e.VuAmaterno)
                    .HasColumnName("VU_AMaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuApaterno)
                    .HasColumnName("VU_APaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuNombre)
                    .HasColumnName("VU_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.VuCelular).HasColumnName("VU_Celular");

                entity.Property(e => e.VuContraseña)
                    .IsRequired()
                    .HasColumnName("VU_Contraseña")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuCorreo)
                    .IsRequired()
                    .HasColumnName("VU_Correo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuDireccion)
                    .IsRequired()
                    .HasColumnName("VU_Direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuEstado)
                    .IsRequired()
                    .HasColumnName("VU_Estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuHorario)
                    .IsRequired()
                    .HasColumnName("VU_Horario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuSexo)
                 .IsRequired()
                 .HasColumnName("VU_Sexo")
                 .HasMaxLength(50)
                 .IsUnicode(false);

                entity.Property(e => e.DuFechaNacimiento)
                    .HasColumnName("DU_FechaNacimiento")
                    .HasColumnType("date");
            });
        }
    }
}
