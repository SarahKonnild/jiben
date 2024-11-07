using JiBen.Server.Data.Models;

namespace JiBen.Server.Data.Repository;

/// <inheritdoc />
public partial class Repository
{
    /// <inheritdoc />
    public void CreateJiBenSystem(string companyName)
    {
        var newJiBen = new JiBenSystem
        {
            CompanyName = companyName
        };

        jiBenDbContext.JiBenSystems.Add(newJiBen);
        jiBenDbContext.SaveChanges();
    }

    /// <inheritdoc />
    public void UpdateJiBenSystem(JiBenSystem newJiBenSystem)
    {
        var existingJiBenSystem = jiBenDbContext.JiBenSystems.Find(newJiBenSystem.Id);
        if (existingJiBenSystem is null)
        {
            return;
        }

        jiBenDbContext.Entry(existingJiBenSystem).CurrentValues.SetValues(newJiBenSystem);
        jiBenDbContext.SaveChanges();
    }

    /// <inheritdoc />
    public JiBenSystem GetJiBenSystem()
    {
        return jiBenDbContext.JiBenSystems.Find(1)!;
    }
}