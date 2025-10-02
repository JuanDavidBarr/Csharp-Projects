using Microsoft.EntityFrameworkCore;
using Veterinary.Models;

namespace Veterinary.Data;

public class PgDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Vet> Vets { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<MedicalRecord>  MedicalRecords { get; set; }
    
    public string ConnectionString { get; set; }

    public PgDbContext()
    {
        // ConnectionString =
        //     "Host=db.pvowgtyfwsxtcvkbxrxf.supabase.co;Database=Veterinary;Username=postgres;Password=JiGLm2WfPEVYuUj7";
        // ConnectionString =
        //     "Host=db.pvowgtyfwsxtcvkbxrxf.supabase.co;Port=5432;Database=Veterinary;Username=postgres;Password=JiGLm2WfPEVYuUj7;SSL Mode=Require;Trust Server Certificate=true;";
        ConnectionString =
            "Host=aws-1-us-east-2.pooler.supabase.com;Port=5432;Database=Veterinary;Username=postgres.pvowgtyfwsxtcvkbxrxf;Password=JiGLm2WfPEVYuUj7;SSL Mode=Require;Trust Server Certificate=true;";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Pets)
            .WithOne(p => p.Client)
            .HasForeignKey(p => p.ClientId);
        
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.Record)
            .WithOne(r => r.Pet)
            .HasForeignKey<MedicalRecord>(r => r.PetId);
        
        modelBuilder.Entity<MedicalRecord>()
            .HasKey(r => r.RecordId);
        
        modelBuilder.Entity<Visit>()
            .HasKey(v => new { v.VetId, v.PetId });
        
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Vet)
            .WithMany(v => v.Visits)
            .HasForeignKey(v => v.VetId);
        
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Pet)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.PetId);
    }
}