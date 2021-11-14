namespace IlmhubPizza.Models;
public class NewPizza
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [MaxLength(255)]
    [Required]
    public string Title { get; set; }

    [MaxLength(3)]
    [Required]
    public string ShortName { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Required]
    public EPizzaStockStatus StockStatus { get; set; }

    [MaxLength(1024)]
    [Required]
    public string Ingredients { get; set; }

    [Range(0, 1000)]
    [Required]
    public double Price { get; set; }
}