using AutoMapper;
using Cupcake.Application.Interfaces;
using Cupcake.Application.Models.Store;
using Cupcake.Domain.Entities;
using MediatR;

namespace Cupcake.Application.UseCases.ProductUseCases.Queries;

public record GetProductsQuery(string Name, int Skip, int Take) : IRequest<List<ProdutModel>>;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProdutModel>>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProdutModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> result = await _productRepository.GetAllAsync();

        return _mapper.Map<List<ProdutModel>>(result);
    }
}
