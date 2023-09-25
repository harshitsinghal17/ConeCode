using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementAPI.Product;

[Table("Product")]
public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(16, 2)")]
    public decimal Price { get; set; }
}