using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Model;
public class Sale
{
    public int Id { get; set; }
    public List<Product> Products { get; set; } = null!;
    public DateTime Date { get; set; }
    public decimal Total { get; set; }
    public string Client { get; set; } = null!;
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}

public class ModelContext : DbContext
{
    public ModelContext(DbContextOptions options) : base(options)
    {
    }

    protected ModelContext()
    {
    }

    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<Product> Products => Set<Product>();
}

public static class ModelContextExtensions
{
    public static IServiceCollection AddModel(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<ModelContext>(options => options.UseSqlServer(connectionString));
}
