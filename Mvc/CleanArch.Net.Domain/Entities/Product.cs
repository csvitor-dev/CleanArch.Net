namespace CleanArch.Net.Domain.Entities;

public class Product(int id, string name, decimal price)
{
    public int Id { get; } = id;
    public string Name { get; set; } = name;
    public string? Description { get; set; }
    public decimal Price { get; set; } = price;
}