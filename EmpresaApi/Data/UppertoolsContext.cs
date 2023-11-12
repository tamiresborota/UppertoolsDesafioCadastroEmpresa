using System;
using System.Collections.Generic;
using System.Configuration;
using EmpresaApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmpresaApi.Data;

public partial class UppertoolsContext : DbContext
{
    public UppertoolsContext()
    {
    }

    public UppertoolsContext(DbContextOptions<UppertoolsContext> options)
        : base(options)
    {
    }



    public virtual DbSet<Empresa> Empresas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json")
   .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("UppertoolsContext"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Cnpj);

            entity.ToTable("Empresa");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Cep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Logradouro)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeFantasia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("UF");
            entity.Property(e => e.Numero)
               .HasMaxLength(20)
               .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
