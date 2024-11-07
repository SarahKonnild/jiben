using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JiBen.Server.Data.Models.Product;

/// <summary>
///     Represents a product owned by the company. It can be a future product, current product or past product.
/// </summary>
public class Product
{
    /// <summary>
    ///     A unique ID to identify the entry.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    ///     The name of the product.
    /// </summary>
    [MaxLength(512)]
    public required string Name { get; set; }

    /// <summary>
    ///     The projected start date of the project.
    /// </summary>
    public required DateTime ProjectStart { get; set; }

    /// <summary>
    ///     The projected end date of the project.
    ///     Note this is the time the project has reached the end of its lifecycle.
    /// </summary>
    public DateTime? ProjectEnd { get; set; }
}