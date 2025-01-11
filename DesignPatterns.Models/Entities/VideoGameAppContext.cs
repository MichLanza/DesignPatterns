using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Models.Entities;

public partial class VideoGameAppContext : DbContext
{
    public VideoGameAppContext()
    {
    }

    public VideoGameAppContext(DbContextOptions<VideoGameAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Videogame> Videogames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("Uid");

            entity.ToTable("company");

            entity.Property(e => e.Uid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Videogame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__videogam__3213E83FA7105972");

            entity.ToTable("Videogame");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Company).WithMany(p => p.Videogames)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("fk_company_videogame");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
