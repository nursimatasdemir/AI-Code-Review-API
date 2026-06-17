using AiCodeReview.Domain.Common;

namespace AiCodeReview.Domain.Entities;

public class ReviewResult : BaseEntity
{
    public Guid ReviewRequestId { get; set; }
    public string Summary { get; set; } = string.Empty;
    public string SecurityIssues { get; set; } = string.Empty;
    public string CodeQualityIssues { get; set; } = string.Empty;
    public string Suggestions { get; set; } = string.Empty;
    public int SeverityScore { get; set; }

    public ReviewRequest ReviewRequest { get; set; } = null!;
}