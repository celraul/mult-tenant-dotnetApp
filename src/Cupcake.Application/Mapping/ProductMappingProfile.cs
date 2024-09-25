using AutoMapper;
using Cupcake.Application.Models.Store;
using Cupcake.Domain.Entities;

namespace Cupcake.Application.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProdutModel, Product>().ReverseMap();
    }
}
