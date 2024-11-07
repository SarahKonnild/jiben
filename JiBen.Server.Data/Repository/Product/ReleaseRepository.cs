using JiBen.Server.Data.Models.Product;

namespace JiBen.Server.Data.Repository;

public partial class Repository
{
    /// <inheritdoc />
    public void CreateRelease(Product product, string versionNumber, DateTime? releaseDate)
    {
        var release = new Release
        {
            VersionNumber = versionNumber,
            ReleaseDate = releaseDate,
            Product = product
        };

        jiBenDbContext.ProductReleases.Add(release);
        jiBenDbContext.SaveChanges();
    }

    /// <inheritdoc />
    public void UpdateRelease(Release updatedRelease)
    {
        var existingRelease = jiBenDbContext.ProductReleases.Find(updatedRelease.Id);
        if (existingRelease is null)
        {
            return;
        }
        
        jiBenDbContext.Entry(existingRelease).CurrentValues.SetValues(updatedRelease);
        jiBenDbContext.SaveChanges();
    }

    /// <inheritdoc />
    public List<Release> GetAllReleases()
    {
        return jiBenDbContext.ProductReleases.ToList();
    }
    
    /// <inheritdoc />
    public List<Release> GetAllReleasesForProduct(Product product)
    {
        return jiBenDbContext.ProductReleases.Where(release => release.Product == product).ToList();
    }

    /// <inheritdoc />
    public Release? GetReleaseById(int id)
    {
        return jiBenDbContext.ProductReleases.Find(id);
    }

    /// <inheritdoc />
    public void DeleteRelease(int id)
    {
        var existingRelease = jiBenDbContext.ProductReleases.Find(id);
        if (existingRelease is null)
        {
            return;
        }

        jiBenDbContext.ProductReleases.Remove(existingRelease);
        jiBenDbContext.SaveChanges();
    }
}