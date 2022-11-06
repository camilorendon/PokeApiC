using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pokeApi.Models;

public partial class PokeApiContext : DbContext
{
    public PokeApiContext()
    {
    }

    public PokeApiContext(DbContextOptions<PokeApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InicioSesion> InicioSesions { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("server=CAMILO-RENDON12\\SERVICIOCAMILO; database=POKE_API; integrated security=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InicioSesion>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("PK__INICIO_S__C3C6C6F1C4B4C72B");

            entity.ToTable("INICIO_SESION");

            entity.Property(e => e.IdLogin).ValueGeneratedOnAdd();
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdLoginNavigation).WithOne(p => p.InicioSesion)
                .HasForeignKey<InicioSesion>(d => d.IdLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INICIO_SE__IdLog__5070F446");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__REGISTRO__FFA45A9961846B81");

            entity.ToTable("REGISTRO");

            entity.Property(e => e.IdRegistro).ValueGeneratedOnAdd();
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRegistroNavigation).WithOne(p => p.Registro)
                .HasForeignKey<Registro>(d => d.IdRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__REGISTRO__IdRegi__4D94879B");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF97A921F958");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
