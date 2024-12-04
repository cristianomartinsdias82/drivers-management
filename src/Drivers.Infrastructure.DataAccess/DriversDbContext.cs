using Drivers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drivers.Infrastructure.DataAccess;

public class DriversDbContext : DbContext
{
    public DriversDbContext(DbContextOptions<DriversDbContext> options) : base(options)
    {
    }

    public DbSet<Driver> Drivers { get; private set; } = default!;
    public DbSet<Achievement> Achievements { get; private set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasOne(drv => drv.Driver)
                .WithMany(ach => ach.Achievements)
                .HasForeignKey(achFk => achFk.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Achievements_Driver");
        });

        modelBuilder.Entity<Driver>()
            .HasData(
                Driver.Create("Eneas Martins Dias",DateOnly.FromDateTime(DateTime.Parse("2024/10/01"))),
                Driver.Create("Maria Aparecida Martins Dias",DateOnly.FromDateTime(DateTime.Parse("2024/09/01"))),
                Driver.Create("Erica Martins Dias",DateOnly.FromDateTime(DateTime.Parse("2024/09/01"))),
                Driver.Create("Cristiano Martins Dias",DateOnly.FromDateTime(DateTime.Parse("2024/11/01"))),
                Driver.Create("Adriana da Silva de Sena",DateOnly.FromDateTime(DateTime.Parse("2024/08/01")))
                    );
    }
}