using AiCodeReview.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AiCodeReview.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Repository> Repositories { get; }
    DbSet<ReviewRequest> ReviewRequests { get; }
    DbSet<ReviewResult> ReviewResults { get; }
    DbSet<ReviewConfiguration> ReviewConfigurations { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}