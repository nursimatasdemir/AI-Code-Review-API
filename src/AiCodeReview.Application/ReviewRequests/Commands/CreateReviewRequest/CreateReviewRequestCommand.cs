using MediatR;

namespace AiCodeReview.Application.ReviewRequests.Commands.CreateReviewRequest;

public class CreateReviewRequestCommand : IRequest<Guid>
{
    public string GitHubRepoId { get; set; } = string.Empty;
    public int PullRequestNumber { get; set; }
    public string PullRequestTitle { get; set; } = string.Empty;
    public string AuthorLogin { get; set; } = string.Empty;
    public string DiffContent { get; set; } = string.Empty;
}