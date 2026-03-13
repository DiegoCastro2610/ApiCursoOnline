using System;
using System.Collections.Generic;
using CursoOnline.Domains;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Contexts;

public partial class CursoOnlineContext : DbContext
{
    public CursoOnlineContext()
    {
    }

    public CursoOnlineContext(DbContextOptions<CursoOnlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ALUNO> ALUNO { get; set; }

    public virtual DbSet<CURSO> CURSO { get; set; }

    public virtual DbSet<INSTRUTOR> INSTRUTOR { get; set; }

    public virtual DbSet<MATRICULA> MATRICULA { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=D11S31-1313840\\SQLEXPRESS;Database=CursoOnline;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ALUNO>(entity =>
        {
            entity.HasKey(e => e.AlunoID).HasName("PK__ALUNO__C1967C6FBD1510A2");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CURSO>(entity =>
        {
            entity.HasKey(e => e.CursoID).HasName("PK__CURSO__7E023A37B9C0E1E6");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.FK_Instrutor).WithMany(p => p.CURSO)
                .HasForeignKey(d => d.FK_InstrutorID)
                .HasConstraintName("FK__CURSO__FK_Instru__4E88ABD4");
        });

        modelBuilder.Entity<INSTRUTOR>(entity =>
        {
            entity.HasKey(e => e.InstrutorID).HasName("PK__INSTRUTO__096B84F47C14EBA6");

            entity.Property(e => e.AreaDeEspecializacao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MATRICULA>(entity =>
        {
            entity.HasKey(e => e.MatriculaID).HasName("PK__MATRICUL__908CEE222683325A");

            entity.HasOne(d => d.FK_Aluno).WithMany(p => p.MATRICULA)
                .HasForeignKey(d => d.FK_AlunoID)
                .HasConstraintName("FK__MATRICULA__FK_Al__52593CB8");

            entity.HasOne(d => d.FK_Curso).WithMany(p => p.MATRICULA)
                .HasForeignKey(d => d.FK_CursoID)
                .HasConstraintName("FK__MATRICULA__FK_Cu__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
