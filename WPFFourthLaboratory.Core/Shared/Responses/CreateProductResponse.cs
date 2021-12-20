using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.Shared.Responses
{
    public class CreateProductResponse
    {
        public Product Product { get; set; }

        public CreateProductResponse(Product product)
        {
            Product = product;
        }
    }
}