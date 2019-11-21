using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestionarProgresoV2.Models
{
    public partial class BD_GestionarProgresoV2Context : DbContext
    {
        public BD_GestionarProgresoV2Context()
        {
        }

        public BD_GestionarProgresoV2Context(DbContextOptions<BD_GestionarProgresoV2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TProgreso> TProgreso { get; set; }
        public virtual DbSet<TDia> TDia { get; set; }
        public virtual DbSet<TNivel> TNivel { get; set; }
        public virtual DbSet<TNivelxTipoNivel> TNivelxTipoNivel { get; set; }
        public virtual DbSet<TSemana> TSemana { get; set; }
        public virtual DbSet<TSemanaxDia> TSemanaxDia { get; set; }
        public virtual DbSet<TTipoNivel> TTipoNivel { get; set; }
        public virtual DbSet<TTipoUsuario> TTipoUsuario { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-VLJRLSBM;Database=BD_GestionarProgresoV2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TDia>(entity =>
            {
                entity.HasKey(e => e.PkIdDia);

                entity.ToTable("T_Dia");

                entity.Property(e => e.PkIdDia)
                    .HasColumnName("PK_ID_Dia")
                    .ValueGeneratedNever();

                entity.Property(e => e.VdNombreDia)
                    .IsRequired()
                    .HasColumnName("VD_NombreDia")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

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
                entity.HasKey(e => e.PkIpProgreso);

                entity.ToTable("T_Progreso");

                entity.Property(e => e.PkIpProgreso).HasColumnName("PK_IP_Progreso");

                entity.Property(e => e.DpNotaHabilidad).HasColumnName("DP_NotaHabilidad");

                entity.Property(e => e.DpNotaInteres).HasColumnName("DP_NotaInteres");

                entity.Property(e => e.DpNotaPasos).HasColumnName("DP_NotaPasos");

                entity.Property(e => e.DpNotaTecnica).HasColumnName("DP_NotaTecnica");

                entity.Property(e => e.DpTotalNota)
                    .HasColumnName("DP_TotalNota")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FkIsdSemanaxDia).HasColumnName("FK_ISD_SemanaxDia");

                entity.Property(e => e.FkIuDni).HasColumnName("FK_IU_Dni");

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

                entity.HasOne(d => d.FkIsdSemanaxDiaNavigation)
                    .WithMany(p => p.TProgreso)
                    .HasForeignKey(d => d.FkIsdSemanaxDia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Progreso_T_SemanaxDia");

                entity.HasOne(d => d.FkIuDniNavigation)
                    .WithMany(p => p.TProgreso)
                    .HasForeignKey(d => d.FkIuDni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Progreso_T_Usuario1");
            });

            modelBuilder.Entity<TSemana>(entity =>
            {
                entity.HasKey(e => e.PkIsSemana);

                entity.ToTable("T_Semana");

                entity.Property(e => e.PkIsSemana)
                    .HasColumnName("PK_IS_Semana")
                    .ValueGeneratedNever();

                entity.Property(e => e.VsNombreSemana)
                    .IsRequired()
                    .HasColumnName("VS_NombreSemana")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TSemanaxDia>(entity =>
            {
                entity.HasKey(e => e.PkIsdSemanaxDia);

                entity.ToTable("T_SemanaxDia");

                entity.Property(e => e.PkIsdSemanaxDia).HasColumnName("PK_ISD_SemanaxDia");

                entity.Property(e => e.FkIdDia).HasColumnName("FK_ID_Dia");

                entity.Property(e => e.FkIsSemana).HasColumnName("FK_IS_Semana");

                entity.HasOne(d => d.FkIdDiaNavigation)
                    .WithMany(p => p.TSemanaxDia)
                    .HasForeignKey(d => d.FkIdDia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_SemanaxDia_T_Dia");

                entity.HasOne(d => d.FkIsSemanaNavigation)
                    .WithMany(p => p.TSemanaxDia)
                    .HasForeignKey(d => d.FkIsSemana)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_SemanaxDia_T_Semana");
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
        }
    }
}
