using AiCodeReview.Application.Common.Interfaces;
using AiCodeReview.Domain.Entities;
using AiCodeReview.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AiCodeReview.Application.ReviewRequests.Commands.CreateReviewRequest;

public class CreateReviewRequestCommandHandler : IRequestHandler<CreateReviewRequestCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateReviewRequestCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateReviewRequestCommand request, CancellationToken cancellationToken)
    {
        var repository = await _context.Repositories.FirstOrDefaultAsync(r=>r.GitHubRepoId == request.GitHubRepoId, cancellationToken);

        if (repository is null)
        {
            throw new InvalidOperationException(
                $"Repository with GitHubRepoId '{request.GitHubRepoId}' is not registered.");
        }

        var reviewRequest = new ReviewRequest
        {
            RepositoryId = repository.Id,
            PullRequestNumber = request.PullRequestNumber,
            PullRequestTitle = request.PullRequestTitle,
            AuthorLogin = request.AuthorLogin,
            DiffContent = request.DiffContent,
            Status = ReviewStatus.Pending
        };
        
        _context.ReviewRequests.Add(reviewRequest);
        await _context.SaveChangesAsync(cancellationToken);
        
        return reviewRequest.Id;
    }
}