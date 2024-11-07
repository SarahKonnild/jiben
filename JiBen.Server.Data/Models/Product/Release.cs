using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JiBen.Server.Data.Models.Product;

/// <summary>
///     Represents a product release. It can be a past, current or future release.
/// </summary>
public class Release
{
    /// <summary>
    ///     A unique ID to identify the entry.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    ///     The version number.
    ///     It is a string so it also supports RCs, weird names, etc.
    /// </summary>
    [MaxLength(200)]
    public required string VersionNumber { get; set; }

    /// <summary>
    ///     The version's release date.
    /// </summary>
    public DateTime? ReleaseDate { get; set; }

    /// <summary>
    ///     The product that this version belongs to.
    /// </summary>
    public required Product Product { get; set; }
}