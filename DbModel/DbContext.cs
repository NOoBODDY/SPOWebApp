using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.DbModel;

public class CarDbContext:DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options):base(options)
    {
        Database.EnsureCreated();
    }

    /*public CarDbContext()
    {
        
    }*/

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=carshowroom;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        base.OnConfiguring(optionsBuilder);
    }*/


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasOne(c => c.Size)
            .WithOne(s => s.Car)
            .HasForeignKey<CarSize>(t => t.CarId);
        modelBuilder.Entity<CarSize>()
            .HasOne(c => c.Car)
            .WithOne(s => s.Size)
            .HasForeignKey<Car>(t => t.SizeId);
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Order)
            .WithOne(o => o.Contract)
            .HasForeignKey<Order>(o => o.ContractId);


        string adminRoleName = "admin";
        string userRoleName = "user";
        string sellerRoleName = "seller";
        string adminEmail = "admin@mail.ru";
        string adminPassword = "123456";
        
        Role adminRole = new Role(adminRoleName)
        {
            Id = 1
        };
        Role userRole = new Role (userRoleName)
        {
            Id = 2
        };
        Role selerRole = new Role (sellerRoleName)
        {
            Id = 3
        };
        User adminUser = new User(adminEmail, adminPassword, adminRole.Id) { Id = 1 };
        
        modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole, selerRole});
        modelBuilder.Entity<User>().HasData(new User[] { adminUser});
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Color> Colors { get; set; } = null!;
    public DbSet<Complectation> Complectations { get; set; } = null!;
    public DbSet<FuelType> FuelTypes { get; set; } = null!;
    public DbSet<Manufacture> Manufactures { get; set; } = null!;
    public DbSet<CarSize> CarSizes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;

    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
}