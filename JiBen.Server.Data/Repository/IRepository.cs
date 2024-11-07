using JiBen.Server.Data.Models;

namespace JiBen.Server.Data.Repository;

public interface IRepository
{
    #region JiBenSystem

    /// <summary>
    ///     Create a new JiBen system.
    /// </summary>
    /// <param name="companyName">The name of the company.</param>
    public void CreateJiBenSystem(string companyName);

    /// <summary>
    ///     Update the existing JiBen system.
    /// </summary>
    /// <param name="newJiBenSystem">The updated JiBen system object.</param>
    public void UpdateJiBenSystem(JiBenSystem newJiBenSystem);

    /// <summary>
    ///     Fetch the existing JiBen system.
    /// </summary>
    /// <returns>The JiBen system.</returns>
    public JiBenSystem GetJiBenSystem();

    #endregion
}