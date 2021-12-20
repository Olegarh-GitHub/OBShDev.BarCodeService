using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.Shared.Requests
{
    public class CreateProductRequest
    {
        public Product Product { get; set; }
        public Producer Producer { get; set; }
        public Country Country { get; set; }

        public CreateProductRequest(Product product, Country country, Producer producer)
        {
            Product = product;
            Country = country;
            Producer = producer;
        }
    }
}