using ECommerce.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebAPI.Contens;

public class MsSqlContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1907; Database=Ecomerce_db; User=sa; Password=admin123456789; TrustServerCertificate=true");
    }

    public DbSet<Product> Products { get; set; }
}
