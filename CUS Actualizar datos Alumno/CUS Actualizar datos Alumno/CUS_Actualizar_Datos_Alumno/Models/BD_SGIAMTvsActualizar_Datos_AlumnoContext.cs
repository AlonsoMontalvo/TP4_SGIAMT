using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CUS_Actualizar_Datos_Alumno.Models
{
    public partial class BD_SGIAMTvsActualizar_Datos_AlumnoContext : DbContext
    {
        public BD_SGIAMTvsActualizar_Datos_AlumnoContext()
        {
        }

        public BD_SGIAMTvsActualizar_Datos_AlumnoContext(DbContextOptions<BD_SGIAMTvsActualizar_Datos_AlumnoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCategoría> TCategoría { get; set; }
        public virtual DbSet<TDistrito> TDistrito { get; set; }
        public virtual DbSet<TTipoUsuario> TTipoUsuario { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2E54QI4\\ALONSO_PC;Database=BD_SGIAMTvsActualizar_Datos_Alumno;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCategoría>(entity =>
            {
                entity.HasKey(e => e.PkIcId);

                entity.ToTable("T_Categoría");

                entity.Property(e => e.PkIcId)
                    .HasColumnName("PK_IC_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.VcNombreCat)
                    .IsRequired()
                    .HasColumnName("VC_NombreCat")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TDistrito>(entity =>
            {
                entity.HasKey(e => e.PkIdiCod);

                entity.ToTable("T_Distrito");

                entity.Property(e => e.PkIdiCod)
                    .HasColumnName("PK_IDI_Cod")
                    .ValueGeneratedNever();

                entity.Property(e => e.VdiNombreDis)
                    .IsRequired()
                    .HasColumnName("VDI_NombreDis")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TTipoUsuario>(entity =>
            {
                entity.HasKey(e => e.PkItuTipoUsuario);

                entity.ToTable("T_TipoUsuario");

                entity.Property(e => e.PkItuTipoUsuario)
                    .HasColumnName("PK_ITU_TipoUsuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.VtuNombreTipoUsuario)
                    .IsRequired()
                    .HasColumnName("VTU_NombreTipoUsuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
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

                entity.Property(e => e.FkIcId).HasColumnName("FK_IC_Id");

                entity.Property(e => e.FkIdiCod).HasColumnName("FK_IDI_Cod");

                entity.Property(e => e.FkItuTipoUsuario).HasColumnName("FK_ITU_TipoUsuario");

                entity.Property(e => e.VuAmaterno)
                    .IsRequired()
                    .HasColumnName("VU_AMaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuApaterno)
                    .IsRequired()
                    .HasColumnName("VU_APaterno")
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

                entity.Property(e => e.VuNombre)
                    .IsRequired()
                    .HasColumnName("VU_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VuSexo)
                    .IsRequired()
                    .HasColumnName("VU_Sexo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkIc)
                    .WithMany(p => p.TUsuario)
                    .HasForeignKey(d => d.FkIcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_E_Usuario2");

                entity.HasOne(d => d.FkIdiCodNavigation)
                    .WithMany(p => p.TUsuario)
                    .HasForeignKey(d => d.FkIdiCod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_E_Usuario_E_Distrito");

                entity.HasOne(d => d.FkItuTipoUsuarioNavigation)
                    .WithMany(p => p.TUsuario)
                    .HasForeignKey(d => d.FkItuTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_E_Usuario0");
            });
        }
    }
}
