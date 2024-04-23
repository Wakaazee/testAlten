using System.Text.Json.Serialization;

namespace TestAlten.Domain
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("inventoryStatus")]
        public string? InventoryStatus { get; set; }

        [JsonPropertyName("rating")]
        public int? Rating { get; set; }
    }


    public class ProductsData
    {
        [JsonPropertyName("data")]
        public List<Product> Data { get; set; }
    }
}
