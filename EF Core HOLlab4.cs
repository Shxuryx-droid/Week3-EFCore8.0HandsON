using RetailInventory.Data;
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Retail Inventory – Lab 4: Insert Initial Data");

using var context = new AppDbContext();
await context.Database.EnsureCreatedAsync();

// Avoid inserting duplicates on re-run
if (!await context.Categories.AnyAsync())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    await context.Categories.AddRangeAsync(electronics, groceries);

    var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
    var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

    await context.Products.AddRangeAsync(product1, product2);
    await context.SaveChangesAsync();

    Console.WriteLine("Initial data inserted successfully.");
}
else
{
    Console.WriteLine("Data already exists. No changes made.");
}
