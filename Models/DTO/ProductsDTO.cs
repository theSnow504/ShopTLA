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

    public class ProductDetailsDTO
    {
        public int ProIdDTO { get; set; }

        public int? PrdInventoryDTO { get; set; }

        public string? PrdSizeDTO { get; set; }

        public string? PrdColorDTO { get; set; }

        public double? PrdPriceDTO { get; set; }

        public DateTime? PrdLastUpdateDTO { get; set; }
    }
}
