using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldExampleConsole;

public partial class SamuraiAppDataContext : DbContext
{
    public SamuraiAppDataContext()
    {
    }

    public SamuraiAppDataContext(DbContextOptions<SamuraiAppDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<Samurai> Samurais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB;Initial Catalog = SamuraiAppData");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasIndex(e => e.SamuraiId, "IX_Quotes_SamuraiId");

            entity.HasOne(d => d.Samurai).WithMany(p => p.Quotes).HasForeignKey(d => d.SamuraiId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
