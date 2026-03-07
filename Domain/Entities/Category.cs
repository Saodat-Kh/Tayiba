namespace Domain.Entities;

public class Category : BaseEntities
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public List<Product> Products { get; set; }
}