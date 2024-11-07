using JiBen.Server.Data.Models.Product;

namespace JiBen.Server.Data.Test;

public partial class DatabaseTest
{
    [Fact]
    public void Should_CreateNewProduct_When_CreatingProduct()
    {
        // ARRANGE
        var expectedProduct = CreateTestProduct();
        
        // ACT
        _repository.CreateProduct(expectedProduct.Name, expectedProduct.ProjectStart);
        
        // ASSERT
        var products = _jiBenDbContext.Products.ToList();
        Assert.Contains(products, p => p.Name == expectedProduct.Name);
    }

    [Fact]
    public void Should_UpdateProduct_When_UpdatingProduct()
    {
        // ARRANGE
        var expectedProduct = CreateTestProduct();

        _jiBenDbContext.Products.Add(expectedProduct);
        _jiBenDbContext.SaveChanges();

        var originalName = expectedProduct.Name;
        var newName = "Faker Product";
        expectedProduct.Name = newName;

        // ACT
        _repository.UpdateProduct(expectedProduct);

        //ASSERT
        var products = _jiBenDbContext.Products.ToList();
        Assert.Contains(products, p => p.Name == newName);
        Assert.DoesNotContain(products, p => p.Name == originalName);
    }

    [Fact]
    public void Should_GetAllProducts_When_GettingProducts()
    {
        // ARRANGE
        var expectedProduct = CreateTestProduct();

        _jiBenDbContext.Products.Add(expectedProduct);
        _jiBenDbContext.SaveChanges();
        
        // ACT
        var fetchedProducts = _repository.GetAllProducts();

        // ASSERT
        Assert.Single(fetchedProducts);
        Assert.Equal(fetchedProducts.First(), expectedProduct);
    }

    [Fact]
    public void Should_GetSingleProduct_When_GettingProductById()
    {
        // ARRANGE
        var expectedProduct = CreateTestProduct();

        _jiBenDbContext.Products.Add(expectedProduct);
        _jiBenDbContext.SaveChanges();
        
        // ACT
        var fetchedProduct = _repository.GetProductById(expectedProduct.Id);

        // ASSERT
        Assert.Equal(expectedProduct, fetchedProduct);
    }

    [Fact]
    public void Should_DeleteProduct_When_DeletingProductById()
    {
        // ARRANGE
        var expectedProduct = CreateTestProduct();

        _jiBenDbContext.Products.Add(expectedProduct);
        _jiBenDbContext.SaveChanges();
        
        // ACT
        _repository.DeleteProduct(expectedProduct.Id);
        
        // ASSERT
        Assert.Empty(_jiBenDbContext.Products);
    }

    private Product CreateTestProduct()
    {
        return new Product
        {
            Name = "Fake Product",
            ProjectStart = new DateTime(2024, 11, 07, 18, 44, 19).ToUniversalTime()
        };
    }
}