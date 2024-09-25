namespace Cupcake.Application.Models.Common;

public class BaseEntityModel
{
    public string Id { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
