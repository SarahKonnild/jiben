using JiBen.Server.Data.Models.Product;

namespace JiBen.Server.Data.Test;

public partial class DatabaseTest
{
    [Fact]
    public void Should_CreateNewRelease_When_CreatingRelease()
    {
        // ARRANGE
        var expectedRelease = CreateTestRelease();
        
        // ACT
        _repository.CreateRelease(expectedRelease.Product, expectedRelease.VersionNumber, expectedRelease.ReleaseDate);
        
        // ASSERT
        var releases = _jiBenDbContext.ProductReleases.ToList();
        Assert.Contains(releases, r => r.VersionNumber == expectedRelease.VersionNumber);
    }

    [Fact]
    public void Should_UpdateRelease_When_UpdatingRelease()
    {
        // ARRANGE
        var expectedRelease = CreateTestRelease();

        _jiBenDbContext.ProductReleases.Add(expectedRelease);
        _jiBenDbContext.SaveChanges();

        var originalRelease = expectedRelease.ReleaseDate;
        var newRelease = new DateTime(2024, 11, 13);
        expectedRelease.ReleaseDate = newRelease;

        // ACT
        _repository.UpdateRelease(expectedRelease);

        //ASSERT
        var releases = _jiBenDbContext.ProductReleases.ToList();
        Assert.Contains(releases, r => r.ReleaseDate == newRelease);
        Assert.DoesNotContain(releases, r => r.ReleaseDate == originalRelease);
    }

    [Fact]
    public void Should_GetAllReleases_When_GettingAllReleases()
    {
        // ARRANGE
        var expectedRelease = CreateTestRelease();

        _jiBenDbContext.ProductReleases.Add(expectedRelease);
        _jiBenDbContext.SaveChanges();
        
        // ACT
        var fetchedReleases = _repository.GetAllReleases();

        // ASSERT
        Assert.Single(fetchedReleases);
        Assert.Equal(fetchedReleases.First(), expectedRelease);
    }

    [Fact]
    public void Should_GetSingleRelease_When_GettingReleaseById()
    {
        // ARRANGE
        var expectedRelease = CreateTestRelease();

        _jiBenDbContext.ProductReleases.Add(expectedRelease);
        _jiBenDbContext.SaveChanges();
        
        // ACT
        var fetchedRelease = _repository.GetReleaseById(expectedRelease.Id);

        // ASSERT
        Assert.Equal(expectedRelease, fetchedRelease);
    }

    [Fact]
    public void Should_GetAllReleasesForProduct_When_GettingAllReleasesForProduct()
    {
        // ARRANGE
        var expectedRelease = CreateTestRelease();

        _jiBenDbContext.ProductReleases.Add(expectedRelease);
        _jiBenDbContext.SaveChanges();
        
        // ACT
        var fetchedReleases = _repository.GetAllReleasesForProduct(expectedRelease.Product);
        
        // ASSERT
        Assert.Single(fetchedReleases);
    }

    [Fact]
    public void Should_DeleteRelease_When_DeletingReleaseById()
    {
        // ARRANGE
        var expectedRelease = CreateTestRelease();

        _jiBenDbContext.ProductReleases.Add(expectedRelease);
        _jiBenDbContext.SaveChanges();
        
        // ACT
        _repository.DeleteProduct(expectedRelease.Id);
        
        // ASSERT
        Assert.Empty(_jiBenDbContext.ProductReleases);
    }

    private Release CreateTestRelease()
    {
        return new Release
        {
            VersionNumber = "1.0.0-rc3",
            Product = CreateTestProduct()
        };
    }
}