# Week3-EFCore8.0HandsON
# Retail Inventory System using EF Core (Labs 1–5)

This project is a step-by-step .NET console application built to teach **Entity Framework Core (EF Core)** and **Object-Relational Mapping (ORM)**. It simulates a basic inventory system for a retail store using **C#**, **EF Core**, and **SQL Server**.

---

## Labs Overview

| Lab | Title                                 | Goal                                      |
|-----|---------------------------------------|-------------------------------------------|
| 1   | Understanding ORM                     | Learn what ORM is and why EF Core helps   |
| 2   | Setting Up the DbContext              | Define models and configure EF Core       |
| 3   | Creating & Applying Migrations        | Use EF Core CLI to create the database    |
| 4   | Inserting Initial Data                | Seed products and categories              |
| 5   | Retrieving Data from Database         | Query data using async EF Core methods    |

---

## Lab 1: Understanding ORM

- **ORM (Object-Relational Mapping)** maps:
  - Class ➝ Table
  - Property ➝ Column
  - Object ➝ Row
- **EF Core** simplifies DB access using C#.
- **Benefits**: Clean code, no SQL, easier updates, async support.

---

## Lab 2: Set Up Models & DbContext

### Models

```csharp
public class Category {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}

public class Product {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}

Lab 3: Migrations with EF Core CLI
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
