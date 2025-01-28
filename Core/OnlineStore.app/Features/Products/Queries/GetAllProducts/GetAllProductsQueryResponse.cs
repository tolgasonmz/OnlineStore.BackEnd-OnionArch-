using OnlineStore.app.DTOs;

namespace OnlineStore.app.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public BrandDto Brand { get; set; }
    }
}
