namespace IlmhubPizza.Entities;
public class Pizza
{
    public Pizza(string title, string shortName, EPizzaStockStatus stockStatus, string ingredients, double price)
    {
        Id = Guid.NewGuid();
        Title = title;
        ShortName = shortName;
        StockStatus = stockStatus;
        Ingredients = ingredients;
        Price = price;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [MaxLength(255)]
    [Required]
    public string Title { get; set; }

    [MaxLength(3)]
    [Required]
    public string ShortName { get; set; }

    [Required]
    public EPizzaStockStatus StockStatus { get; set; }

    [MaxLength(1024)]
    [Required]
    public string Ingredients { get; set; }

    [Range(0, 1000)]
    [Required]
    public double Price { get; set; }
}