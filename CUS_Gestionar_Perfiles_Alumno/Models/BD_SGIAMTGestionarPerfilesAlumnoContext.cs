﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CUS_Gestionar_Perfiles_Alumno.Models
{
    public partial class BD_SGIAMTGestionarPerfilesAlumnoContext : DbContext
    {
        public BD_SGIAMTGestionarPerfilesAlumnoContext()
        {
        }

        public BD_SGIAMTGestionarPerfilesAlumnoContext(DbContextOptions<BD_SGIAMTGestionarPerfilesAlumnoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TTipoUsuario> TTipoUsuario { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2E54QI4\\ALONSO_PC;Database=BD_SGIAMTGestionarPerfilesAlumno;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
