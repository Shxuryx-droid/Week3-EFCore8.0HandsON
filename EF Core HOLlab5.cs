using RetailInventory.Data;
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Retail Inventory – Lab 5: Retrieve Data");

using var context = new AppDbContext();

// ✅ 1. Retrieve All Products
var products = await context.Products.ToListAsync();
Console.WriteLine("\nAll Products:");
foreach (var p in products)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");

// ✅ 2. Find by ID
var product = await context.Products.FindAsync(1);
Console.WriteLine($"\nFind by ID 1: {product?.Name ?? "Not Found"}");

// ✅ 3. FirstOrDefault with Condition (Price > ₹50,000)
var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
Console.WriteLine($"\nExpensive Product: {expensive?.Name ?? "None found"}");
