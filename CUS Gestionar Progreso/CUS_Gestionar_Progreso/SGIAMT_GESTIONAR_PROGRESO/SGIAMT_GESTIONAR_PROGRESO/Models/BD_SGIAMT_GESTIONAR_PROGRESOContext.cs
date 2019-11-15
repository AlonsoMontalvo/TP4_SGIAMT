using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGIAMT_GESTIONAR_PROGRESO.Models
{
    public partial class BD_SGIAMT_GESTIONAR_PROGRESOContext : DbContext
    {
        public BD_SGIAMT_GESTIONAR_PROGRESOContext()
        {
        }

        public BD_SGIAMT_GESTIONAR_PROGRESOContext(DbContextOptions<BD_SGIAMT_GESTIONAR_PROGRESOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TNivel> TNivel { get; set; }
        public virtual DbSet<TNivelxTipoNivel> TNivelxTipoNivel { get; set; }
        public virtual DbSet<TProgreso> TProgreso { get; set; }
        public virtual DbSet<TTipoNivel> TTipoNivel { get; set; }
        public virtual DbSet<TTipoUsuario> TTipoUsuario { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }
        public virtual DbSet<TUsuarioxProgreso> TUsuarioxProgreso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-VLJRLSBM;Database=BD_SGIAMT_GESTIONAR_PROGRESO;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TNivel>(entity =>
            {
                entity.HasKey(e => e.PkInCod);

                entity.ToTable("T_Nivel");

                entity.Property(e => e.PkInCod)
                    .HasColumnName("PK_IN_Cod")
                    .ValueGeneratedNever();

                entity.Property(e => e.VnNombreNivel)
                    .IsRequired()
                    .HasColumnName("VN_NombreNivel")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TNivelxTipoNivel>(entity =>
            {
                entity.HasKey(e => e.PkIntnCod);

                entity.ToTable("T_NivelxTipoNivel");

                entity.Property(e => e.PkIntnCod).HasColumnName("PK_INTN_Cod");

                entity.Property(e => e.FkInCod).HasColumnName("FK_IN_Cod");

                entity.Property(e => e.FkItnCod).HasColumnName("FK_ITN_Cod");

                entity.Property(e => e.FkIuDni).HasColumnName("FK_IU_Dni");

                entity.Property(e => e.NroAlumno).HasColumnName("Nro_Alumno");

                entity.HasOne(d => d.FkInCodNavigation)
                    .WithMany(p => p.TNivelxTipoNivel)
                    .HasForeignKey(d => d.FkInCod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_E_NivelxTipoNivel8");

                entity.HasOne(d => d.FkItnCodNavigation)
                    .WithMany(p => p.TNivelxTipoNivel)
                    .HasForeignKey(d => d.FkItnCod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_E_NivelxTipoNivel7");

                entity.HasOne(d => d.FkIuDniNavigation)
                    .WithMany(p => p.TNivelxTipoNivel)
                    .HasForeignKey(d => d.FkIuDni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_E_NivelxTipoNivel_E_Usuario");
            });

            modelBuilder.Entity<TProgreso>(entity =>
            {
                entity.HasKey(e => e.PkIpCod);

                entity.ToTable("T_Progreso");

                entity.Property(e => e.PkIpCod)
                    .HasColumnName("PK_IP_Cod")
                    .ValueGeneratedNever();

                entity.Property(e => e.DpNotaHabilidad).HasColumnName("DP_NotaHabilidad");

                entity.Property(e => e.DpNotaInteres).HasColumnName("DP_NotaInteres");

                entity.Property(e => e.DpNotaPasos).HasColumnName("DP_NotaPasos");

                entity.Property(e => e.DpNotaTecnica).HasColumnName("DP_NotaTecnica");

                entity.Property(e => e.DpTotalNota)
                    .HasColumnName("DP_TotalNota")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.VpNombreProgreso)
                    .IsRequired()
                    .HasColumnName("VP_NombreProgreso")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VpObservacion)
                    .IsRequired()
                    .HasColumnName("VP_Observacion")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TTipoNivel>(entity =>
            {
                entity.HasKey(e => e.PkItnCod);

                entity.ToTable("T_TipoNivel");

                entity.Property(e => e.PkItnCod)
                    .HasColumnName("PK_ITN_Cod")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItnNombreTipoNivel)
                    .IsRequired()
                    .HasColumnName("ITN_NombreTipoNivel")
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

                entity.HasOne(d => d.FkItuTipoUsuarioNavigation)
                    .WithMany(p => p.TUsuario)
                    .HasForeignKey(d => d.FkItuTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_E_Usuario0");
            });

            modelBuilder.Entity<TUsuarioxProgreso>(entity =>
            {
                entity.HasKey(e => e.PkIuxPCod);

                entity.ToTable("T_UsuarioxProgreso");

                entity.Property(e => e.PkIuxPCod)
                    .HasColumnName("PK_IUxP_Cod")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkIpCod).HasColumnName("FK_IP_Cod");

                entity.Property(e => e.FkIuDni).HasColumnName("FK_IU_Dni");

                entity.Property(e => e.VupNombreProfesor)
                    .IsRequired()
                    .HasColumnName("VUP_NombreProfesor")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VupSemana)
                    .IsRequired()
                    .HasColumnName("VUP_Semana")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkIpCodNavigation)
                    .WithMany(p => p.TUsuarioxProgreso)
                    .HasForeignKey(d => d.FkIpCod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_UsuarioxProgreso_T_Progreso");

                entity.HasOne(d => d.FkIuDniNavigation)
                    .WithMany(p => p.TUsuarioxProgreso)
                    .HasForeignKey(d => d.FkIuDni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_UsuarioxProgreso_T_Usuario");
            });
        }
    }
}
