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

		private ITagRepository tagRepository;

		public AbstractApiTagServerRequestModelValidator(ITagRepository tagRepository)
		{
			this.tagRepository = tagRepository;
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
		}

		public virtual void TagNameRules()
		{
			this.RuleFor(x => x.TagName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.TagName).Length(0, 150).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void WikiPostIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>86d1b4153044069dc71cfeec5b3bbff7</Hash>
</Codenesium>*/