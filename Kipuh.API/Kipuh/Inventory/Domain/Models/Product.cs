namespace Kipuh.API.Kipuh.Inventory.Domain.Models;

public class Product
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Stock { get; set; }
}