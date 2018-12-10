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
    <Hash>2f5735c877cf5907f85b24d201319b1c</Hash>
</Codenesium>*/