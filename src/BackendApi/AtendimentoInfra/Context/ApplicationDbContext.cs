﻿using AtendimentoDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoInfra.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Atendimento> Atendimento { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Group { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
