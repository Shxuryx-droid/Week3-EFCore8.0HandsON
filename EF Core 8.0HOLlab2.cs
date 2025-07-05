Category.cs
// Description: This file defines the Category class for an e-commerce application.
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    // A category can have many products
    public List<Product> Products { get; set; } = new();
}

Product.cs
// Description: This file defines the Product class for an e-commerce application.
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }

    // Foreign key
    public int CategoryId { get; set; }

    // Navigation property
    public Category? Category { get; set; }
}

ApplicationDbContext.cs
// Description: This file defines the ApplicationDbContext class for an e-commerce application.
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connects to SQL Server LocalDB (change as needed)
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RetailDb;Trusted_Connection=True;");
    }
}
