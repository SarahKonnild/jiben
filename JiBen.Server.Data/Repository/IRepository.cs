using JiBen.Server.Data.Models;
using JiBen.Server.Data.Models.Product;

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

    #region Product

    /// <summary>
    ///     Create a new product.
    /// </summary>
    /// <param name="productName">The name of the product.</param>
    /// <param name="projectStart">The time that the project is set to start.</param>
    public void CreateProduct(string productName, DateTime projectStart);

    /// <summary>
    ///     Update an existing product.
    /// </summary>
    /// <param name="updatedProduct">The updated product.</param>
    public void UpdateProduct(Product updatedProduct);

    /// <summary>
    ///     Get all products stored in the database.
    /// </summary>
    /// <returns>The list of products.</returns>
    public List<Product> GetAllProducts();

    /// <summary>
    ///     Get a specific product by its ID.
    /// </summary>
    /// <param name="id">The ID to fetch the product for.</param>
    /// <returns>The product, or null if not found.</returns>
    public Product? GetProductById(int id);

    /// <summary>
    ///     Delete the product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    public void DeleteProduct(int id);

    #endregion

    #region Release

    /// <summary>
    ///     Create a new release.
    /// </summary>
    /// <param name="product">The product that this release belongs to.</param>
    /// <param name="versionNumber">The string version number.</param>
    /// <param name="releaseDate">The projected release date. Is nullable.</param>
    public void CreateRelease(Product product, string versionNumber, DateTime? releaseDate);

    /// <summary>
    ///     Update the release.
    /// </summary>
    /// <param name="updatedRelease">The updated version of the release.</param>
    public void UpdateRelease(Release updatedRelease);

    /// <summary>
    ///     Get all releases, regardless of the product.
    /// </summary>
    /// <returns>The list of all releases in the system.</returns>
    public List<Release> GetAllReleases();

    /// <summary>
    ///     Get the list of releases for a specific product.
    /// </summary>
    /// <param name="product">The product to fetch the releases for.</param>
    /// <returns>The list of releases.</returns>
    public List<Release> GetAllReleasesForProduct(Product product);

    /// <summary>
    ///     The release to fetch by its ID.
    /// </summary>
    /// <param name="id">The ID of the release to fetch.</param>
    /// <returns>The release if found. Otherwise, null.</returns>
    public Release? GetReleaseById(int id);

    /// <summary>
    ///     Delete a release by its ID.
    /// </summary>
    /// <param name="id">The ID of the release to delete.</param>
    public void DeleteRelease(int id);

    #endregion
}