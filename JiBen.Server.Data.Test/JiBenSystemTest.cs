using JiBen.Server.Data.Models;

namespace JiBen.Server.Data.Test;

public partial class DatabaseTest
{
    [Fact]
    public void Should_AddJiBenSystemToDatabase_When_CreatingJiBenSystem()
    {
        // ARRANGE
        var expectedJiBenSystem = CreateTestJiBenSystem();
        
        // ACT
        _repository.CreateJiBenSystem("JiBen Corp.");

        // ASSERT
        var jiBens = _jiBenDbContext.JiBenSystems.ToList();
        Assert.Contains(jiBens, jb => jb.CompanyName == expectedJiBenSystem.CompanyName);
    }

    [Fact]
    public void Should_UpdateJiBenSystemInDatabase_When_UpdatingJiBenSystem()
    {
        // ARRANGE
        var expectedJiBenSystem = CreateTestJiBenSystem();

        _jiBenDbContext.JiBenSystems.Add(expectedJiBenSystem);
        _jiBenDbContext.SaveChanges();

        var originalName = expectedJiBenSystem.CompanyName;
        var newName = "Not JiBen Corp.";
        expectedJiBenSystem.CompanyName = newName;

        // ACT
        _repository.UpdateJiBenSystem(expectedJiBenSystem);

        // ASSERT
        var jiBens = _jiBenDbContext.JiBenSystems.ToList();
        Assert.Contains(jiBens, jb => jb.CompanyName == newName);
        Assert.DoesNotContain(jiBens, jb => jb.CompanyName == originalName);
    }

    [Fact]
    public void Should_GetJiBenSystemInDatabase_When_GettingJiBenSystem()
    {
        // ARRANGE
        var expectedJiBenSystem = CreateTestJiBenSystem();

        _jiBenDbContext.JiBenSystems.Add(expectedJiBenSystem);
        _jiBenDbContext.SaveChanges();
        
        // ACT
        var fetchedJiBenSystem = _repository.GetJiBenSystem();

        // ASSERT
        Assert.Equal(expectedJiBenSystem, fetchedJiBenSystem);
    }

    private JiBenSystem CreateTestJiBenSystem()
    {
        return new JiBenSystem
        {
            CompanyName = "JiBen Corp."
        };
    }
}