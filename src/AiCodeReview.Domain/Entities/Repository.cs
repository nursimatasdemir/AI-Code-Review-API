using AiCodeReview.Domain.Common;

namespace AiCodeReview.Domain.Entities;

public class Repository : BaseEntity
{
    public string GitHubRepoId { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string RepoName { get; set; } = string.Empty;
    public string InstallationId { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    
    public ReviewConfiguration? Configuration { get; set; }
    public ICollection<ReviewRequest> ReviewRequests { get; set; } = new List<ReviewRequest>();
}
