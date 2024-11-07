using Microsoft.Extensions.Logging;

namespace JiBen.Server.Data.Repository;

/// <inheritdoc />
public partial class Repository(ILogger<Repository> logger, JiBenDbContext jiBenDbContext) : IRepository;