using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiTagServerRequestModelValidator : AbstractValidator<ApiTagServerRequestModel>
	{
		private int existingRecordId;

		protected ITagRepository TagRepository { get; private set; }

		public AbstractApiTagServerRequestModelValidator(ITagRepository tagRepository)
		{
			this.TagRepository = tagRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTagServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountRules()
		{
		}

		public virtual void ExcerptPostIdRules()
		{
			this.RuleFor(x => x.ExcerptPostId).MustAsync(this.BeValidPostByExcerptPostId).When(x => !x?.ExcerptPostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TagNameRules()
		{
			this.RuleFor(x => x.TagName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.TagName).Length(0, 150).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void WikiPostIdRules()
		{
			this.RuleFor(x => x.WikiPostId).MustAsync(this.BeValidPostByWikiPostId).When(x => !x?.WikiPostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPostByExcerptPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TagRepository.PostByExcerptPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPostByWikiPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TagRepository.PostByWikiPostId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>e09a2b6efe608c9259a86028ae34ad73</Hash>
</Codenesium>*/