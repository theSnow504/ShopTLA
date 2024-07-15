namespace ShopTLA.Models.DTO
{
    public class ProductsDTO
    {
        public int? CatIdDTO { get; set; }

        public string ProNameDTO { get; set; } = null!;

        public double? ProPriceDTO { get; set; }

        public string? ProDescriptionDTO { get; set; }

        public int? NatIdDTO { get; set; }

        public DateTime? ProLastUpdateDTO { get; set; }
    }
}
