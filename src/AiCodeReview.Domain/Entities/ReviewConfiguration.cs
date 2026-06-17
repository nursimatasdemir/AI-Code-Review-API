using AiCodeReview.Domain.Common;
using AiCodeReview.Domain.Enums;

namespace AiCodeReview.Domain.Entities;

public class ReviewConfiguration : BaseEntity
{
    public Guid RepositoryId { get; set; }
    public string Language { get; set; } = "tr";

    public List<ReviewCategory> EnabledCategories { get; set; } = new()
    {
        ReviewCategory.CorrectnessAndFunctionality,
        ReviewCategory.CodeQualityAndReadability,
        ReviewCategory.ArchitectureAndStandards,
        ReviewCategory.Performance,
        ReviewCategory.Security,
        ReviewCategory.TestCoverage,
        ReviewCategory.ErrorHandlingAndLogging
    };

    public string CustomPromptSuffix { get; set; } = string.Empty;
    public int SeverityThreshold { get; set; } = 0;
    
    public Repository Repository { get; set; } = null!;
}