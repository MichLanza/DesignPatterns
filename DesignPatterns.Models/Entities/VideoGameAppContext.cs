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
            entity.HasKey(e => e.Id).HasName("PK__company__3214EC07206C77A8");

            entity.ToTable("company");

            entity.Property(e => e.Id).ValueGeneratedNever();
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
