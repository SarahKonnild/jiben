using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JiBen.Server.Data.Models;

/// <summary>
///     The JiBenSystem defines the context of the application.
/// </summary>
public class JiBenSystem
{
    /// <summary>
    ///     A unique ID to identify the entry.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    /// <summary>
    ///     The name of the company owning the setup.
    /// </summary>
    [MaxLength(512)]
    public required string CompanyName { get; set; }
}