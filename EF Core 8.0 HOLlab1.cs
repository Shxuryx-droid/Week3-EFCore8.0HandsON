//Product.cs
// Description: This file defines the Product class for an e-commerce application.
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}

Category.cs
// Description: This file defines the Category class for an e-commerce application.
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product>? Products { get; set; }
}
RetailDbContext.cs
// Description: This file defines the RetailDbContext class for an e-commerce application.
public class RetailDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RetailInventoryDb;Trusted_Connection=True;");
    }
}

Program.cs
// Description: This file contains the main entry point for the e-commerce application.
using RetailInventory.Data;
using RetailInventory.Models;

using var context = new RetailDbContext();
context.Database.EnsureCreated();  // Create DB if not exists

// Add data if empty
if (!context.Categories.Any())
{
    var cat = new Category { Name = "Electronics" };
    context.Categories.Add(cat);
    context.Products.Add(new Product { Name = "Smartphone", Stock = 50, Category = cat });
    context.SaveChanges();
    Console.WriteLine("Sample data added.");
}
else
{
    foreach (var p in context.Products.Include(p => p.Category))
    {
        Console.WriteLine($"{p.Name} - {p.Stock} in stock - Category: {p.Category?.Name}");
    }
}
