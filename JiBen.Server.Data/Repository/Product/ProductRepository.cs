using JiBen.Server.Data.Models.Product;

namespace JiBen.Server.Data.Repository;

public partial class Repository
{
    /// <inheritdoc />
    public void CreateProduct(string productName, DateTime projectStart)
    {
        var product = new Product
        {
            Name = productName,
            ProjectStart = projectStart
        };

        jiBenDbContext.Products.Add(product);
        jiBenDbContext.SaveChanges();
    }

    /// <inheritdoc />
    public void UpdateProduct(Product updatedProduct)
    {
        var existingProduct = jiBenDbContext.Products.Find(updatedProduct.Id);
        if (existingProduct is null)
        {
            return;
        }
        
        jiBenDbContext.Entry(existingProduct).CurrentValues.SetValues(updatedProduct);
        jiBenDbContext.SaveChanges();
    }

    /// <inheritdoc />
    public List<Product> GetAllProducts()
    {
        return jiBenDbContext.Products.ToList();
    }

    /// <inheritdoc />
    public Product? GetProductById(int id)
    {
        return jiBenDbContext.Products.Find(id);
    }

    /// <inheritdoc />
    public void DeleteProduct(int id)
    {
        var existingProduct = jiBenDbContext.Products.Find(id);
        if (existingProduct is null)
        {
            return;
        }

        jiBenDbContext.Products.Remove(existingProduct);
        jiBenDbContext.SaveChanges();
    }
}