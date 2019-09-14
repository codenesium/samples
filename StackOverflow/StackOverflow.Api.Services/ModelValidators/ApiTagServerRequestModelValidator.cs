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
	public class ApiTagServerRequestModelValidator : AbstractValidator<ApiTagServerRequestModel>, IApiTagServerRequestModelValidator
	{
		private int existingRecordId;

		protected ITagRepository TagRepository { get; private set; }

		public ApiTagServerRequestModelValidator(ITagRepository tagRepository)
		{
			this.TagRepository = tagRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTagServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTagServerRequestModel model)
		{
			this.CountRules();
			this.ExcerptPostIdRules();
			this.TagNameRules();
			this.WikiPostIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagServerRequestModel model)
		{
			this.CountRules();
			this.ExcerptPostIdRules();
			this.TagNameRules();
			this.WikiPostIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>8eeff9b0b95082fcbe2a1a96d9786717</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/