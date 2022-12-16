using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto.Data.Entidades;

namespace Projeto.Data.Contexto;

public partial class TreinamentoContext : DbContext
{

    private readonly IConfiguration _configuration;
    public TreinamentoContext()
    {
    }

    public TreinamentoContext(
        DbContextOptions<TreinamentoContext> options,
        IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Turma> Turmas { get; set; }

    public virtual DbSet<TurmaAluno> TurmaAlunos { get; set; }

    public virtual DbSet<VwTurmasDoAluno> VwTurmasDoAlunos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Sql"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alunos__3214EC073273815D");

            entity.Property(e => e.Aniversario).HasColumnType("datetime");
            entity.Property(e => e.Documento).IsUnicode(false);
            entity.Property(e => e.Matricula)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UltimoNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Turma>(entity =>
        {
            entity.ToTable("Turma");

            entity.Property(e => e.Descricao).IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PeriodoFim).HasColumnType("datetime");
            entity.Property(e => e.PeriodoInicio).HasColumnType("datetime");
        });

        modelBuilder.Entity<TurmaAluno>(entity =>
        {
            entity.HasKey(e => new { e.IdTurma, e.IdAluno });

            entity.ToTable("Turma_Alunos");

            entity.Property(e => e.PeriodoFim).HasColumnType("datetime");
            entity.Property(e => e.PeriodoInicio).HasColumnType("datetime");

            //entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.TurmaAlunos)
            //    .HasForeignKey(d => d.IdAluno)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Turma_Alunos_Alunos");

            //entity.HasOne(d => d.IdTurmaNavigation).WithMany(p => p.TurmaAlunos)
            //    .HasForeignKey(d => d.IdTurma)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Turma_Alunos_Turma");
        });

        modelBuilder.Entity<VwTurmasDoAluno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTurmasDoAluno");

            entity.Property(e => e.Documento).IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
