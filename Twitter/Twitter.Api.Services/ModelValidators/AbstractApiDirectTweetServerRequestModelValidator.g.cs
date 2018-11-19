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
	public abstract class AbstractApiDirectTweetServerRequestModelValidator : AbstractValidator<ApiDirectTweetServerRequestModel>
	{
		private int existingRecordId;

		private IDirectTweetRepository directTweetRepository;

		public AbstractApiDirectTweetServerRequestModelValidator(IDirectTweetRepository directTweetRepository)
		{
			this.directTweetRepository = directTweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDirectTweetServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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

		private async Task<bool> BeValidUserByTaggedUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.directTweetRepository.UserByTaggedUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>65f43b6a6fe16eb2db2736b330ffce0b</Hash>
</Codenesium>*/