using Application.Commands;
using Application.Dtos;
using Domain.Business;
using MediatR;

namespace Application.Handlers
{
    public class ProductHandler : IRequestHandler<CreateProductCommand, ProductDto> 
    {
        private readonly ProductBusiness _productBusiness;

        public ProductHandler(ProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        public Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = new ProductDto
            {
                Id = Guid.NewGuid(),
                Name = _productBusiness.NameFormat(request.Name),
                Description = request.Description
            };

            return Task.FromResult(result);
        }
    }
}

