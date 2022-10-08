using System;
using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class ApplicationContext : DbContext
{
    public DbSet<Audience>? Audiences { get; set; }
    public DbSet<Commission>? Commissions { get; set; }
    public DbSet<CommissionMember>? CommissionMembers { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Equipment>? Equipments { get; set; }
    public DbSet<EquipmentType>? EquipmentTypes { get; set; }
    public DbSet<EquipmentUnit>? EquipmentUnits { get; set; }
    public DbSet<InspectedUnit>? InspectedUnits { get; set; }
    public DbSet<Inventory>? Inventories { get; set; }
    public DbSet<Role>? Roles { get; set; }
    public DbSet<State>? States { get; set; }
    public DbSet<Status>? Statuses { get; set; }
    public DbSet<TrainingCenter>? TrainingCenters { get; set; }
    public DbSet<User>? Users { get; set; }
    
    public ApplicationContext() { }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySql("server=localhost;user=root;password=iuh;database=Inventory;", 
                new MySqlServerVersion(new Version(15, 1)));
    }
}