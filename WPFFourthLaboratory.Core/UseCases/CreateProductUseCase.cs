using WPFFourthLaboratory.DAL.Helpers;
using WPFFourthLaboratory.DAL.Interfaces;
using WPFFourthLaboratory.DAL.Models.Entities;
using WPFFourthLaboratory.DAL.Shared.Requests;
using WPFFourthLaboratory.DAL.Shared.Responses;

namespace WPFFourthLaboratory.DAL.UseCases
{
    public class CreateProductUseCase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Producer> _producerRepository;

        public CreateProductUseCase(
            IRepository<Product> productRepository,
            IRepository<Producer> producerRepository, 
            IRepository<Country> countryRepository)
        {
            _productRepository = productRepository;
            _producerRepository = producerRepository;
            _countryRepository = countryRepository;
        }

        public CreateProductResponse Execute(CreateProductRequest request)
        {
            _countryRepository.Create(request.Country);
            _producerRepository.Create(request.Producer);
            var product = _productRepository.Create(request.Product);
            product.SetCode();
            return new CreateProductResponse(product);
        }
    }
}