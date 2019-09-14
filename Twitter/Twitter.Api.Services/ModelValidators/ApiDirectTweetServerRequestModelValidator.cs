using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiDirectTweetServerRequestModelValidator : AbstractValidator<ApiDirectTweetServerRequestModel>, IApiDirectTweetServerRequestModelValidator
	{
		private int existingRecordId;

		protected IDirectTweetRepository DirectTweetRepository { get; private set; }

		public ApiDirectTweetServerRequestModelValidator(IDirectTweetRepository directTweetRepository)
		{
			this.DirectTweetRepository = directTweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDirectTweetServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDirectTweetServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.TaggedUserIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDirectTweetServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.TaggedUserIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void ContentRules()
		{
			this.RuleFor(x => x.Content).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Content).Length(0, 140).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DateRules()
		{
		}

		public virtual void TaggedUserIdRules()
		{
			this.RuleFor(x => x.TaggedUserId).MustAsync(this.BeValidUserByTaggedUserId).When(x => !x?.TaggedUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TimeRules()
		{
		}

		protected async Task<bool> BeValidUserByTaggedUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.DirectTweetRepository.UserByTaggedUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>85ee9866cc1b0dd6359a89addb4b0be5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/