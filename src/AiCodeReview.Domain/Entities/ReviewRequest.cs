using AiCodeReview.Domain.Common;
using AiCodeReview.Domain.Enums;

namespace AiCodeReview.Domain.Entities;

public class ReviewRequest : BaseEntity
{
    public Guid RepositoryId { get; set; }
    public int PullRequestNumber { get; set; }
    public string PullRequestTitle { get; set; } = string.Empty;
    public string AuthorLogin { get; set; } = string.Empty;
    public string DiffContent { get; set; } = string.Empty;
    public ReviewStatus Status { get; set; } = ReviewStatus.Pending;

    public Repository Repository { get; set; } = null!;
    public ReviewResult? ReviewResult { get; set; }

}