using Cupcake.Application.Models.Common;

namespace Cupcake.Application.Models.Store;

public class ProdutModel : BaseEntityModel
{
    public string Name { get; set; } = string.Empty;
    public decimal CostPrice { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}
