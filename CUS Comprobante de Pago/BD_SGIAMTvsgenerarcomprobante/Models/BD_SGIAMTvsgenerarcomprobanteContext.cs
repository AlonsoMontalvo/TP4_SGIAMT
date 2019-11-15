using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BD_SGIAMTvsgenerarcomprobante.Models
{
    public partial class BD_SGIAMTvsgenerarcomprobanteContext : DbContext
    {
        public BD_SGIAMTvsgenerarcomprobanteContext()
        {
        }

        public BD_SGIAMTvsgenerarcomprobanteContext(DbContextOptions<BD_SGIAMTvsgenerarcomprobanteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TComprobantePago> TComprobantePago { get; set; }
        public virtual DbSet<TConceptoPago> TConceptoPago { get; set; }
        public virtual DbSet<TPago> TPago { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2E54QI4\\ALONSO_PC;Database=BD_SGIAMTvsgenerarcomprobante;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TComprobantePago>(entity =>
            {
                entity.HasKey(e => e.PkIcpId);

                entity.ToTable("T_Comprobante_Pago");

                entity.Property(e => e.PkIcpId).HasColumnName("PK_ICP_Id");

                entity.Property(e => e.FkIpId).HasColumnName("FK_IP_Id");

                entity.Property(e => e.VcpAmaterno)
                    .HasColumnName("VCP_AMaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VcpApaterno)
                    .HasColumnName("VCP_APaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VcpFecha)
                    .HasColumnName("VCP_Fecha")
                    .HasColumnType("date");

                entity.Property(e => e.VcpMonto)
                    .HasColumnName("VCP_Monto")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.VcpNombre)
                    .HasColumnName("VCP_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VcpPdf).HasColumnName("VCP_Pdf");

                entity.HasOne(d => d.FkIp)
                    .WithMany(p => p.TComprobantePago)
                    .HasForeignKey(d => d.FkIpId)
                    .HasConstraintName("FK__T_Comprob__FK_IP__3F466844");
            });

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
                    .HasConstraintName("FK__T_Pago__FK_ICP_I__3D5E1FD2");

                entity.HasOne(d => d.FkIuDniNavigation)
                    .WithMany(p => p.TPago)
                    .HasForeignKey(d => d.FkIuDni)
                    .HasConstraintName("FK__T_Pago__FK_IU_Dn__3C69FB99");
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
