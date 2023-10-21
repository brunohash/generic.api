using Application.Commands;
using Domain.Dtos;
using Domain.Services;
using MediatR;

namespace Application.Handlers
{
    public class ProductHandler : IRequestHandler<CreateProductCommand, ProductDto> 
    {
        private readonly ProductServices _productServices;

        public ProductHandler(ProductServices productServices)
        {
            _productServices = productServices;
        }

        public Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = new ProductDto
            {
                Id = Guid.NewGuid(),
                Name = _productServices.NameFormat(request.Name),
                Description = request.Description
            };

            return Task.FromResult(result);
        }
    }
}

