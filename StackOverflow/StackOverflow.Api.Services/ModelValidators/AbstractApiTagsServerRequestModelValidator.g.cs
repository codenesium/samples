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
	public abstract class AbstractApiTagsServerRequestModelValidator : AbstractValidator<ApiTagsServerRequestModel>
	{
		private int existingRecordId;

		protected ITagsRepository TagsRepository { get; private set; }

		public AbstractApiTagsServerRequestModelValidator(ITagsRepository tagsRepository)
		{
			this.TagsRepository = tagsRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTagsServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountRules()
		{
		}

		public virtual void ExcerptPostIdRules()
		{
			this.RuleFor(x => x.ExcerptPostId).MustAsync(this.BeValidPostsByExcerptPostId).When(x => !x?.ExcerptPostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TagNameRules()
		{
			this.RuleFor(x => x.TagName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.TagName).Length(0, 150).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void WikiPostIdRules()
		{
			this.RuleFor(x => x.WikiPostId).MustAsync(this.BeValidPostsByWikiPostId).When(x => !x?.WikiPostId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPostsByExcerptPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TagsRepository.PostsByExcerptPostId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPostsByWikiPostId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TagsRepository.PostsByWikiPostId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>7a539c34aa8fffba24de9635e2ede142</Hash>
</Codenesium>*/