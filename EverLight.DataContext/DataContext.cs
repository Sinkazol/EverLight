using EverLight.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EverLight.DC
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Repositories\EverLight\EverLight.DataContext\EverLightDB.mdf;Integrated Security=True");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(e => e.Id).ValueGeneratedOnAdd().UseIdentityColumn(1508, 1);  //legyen generált az id akkor generáljuk amikor létrejön 
            modelBuilder.Entity<Order>().Property(o => o.Id).ValueGeneratedOnAdd().UseIdentityColumn(100, 1);
            modelBuilder.Entity<Employee>()
            .HasMany(b => b.DoneOrders)
            .WithOne(e => e.DoneBy)
            .HasForeignKey(x => x.EmployeeId);

        }
    }
}