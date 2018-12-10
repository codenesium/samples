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

		protected IDirectTweetRepository DirectTweetRepository { get; private set; }

		public AbstractApiDirectTweetServerRequestModelValidator(IDirectTweetRepository directTweetRepository)
		{
			this.DirectTweetRepository = directTweetRepository;
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

		protected async Task<bool> BeValidUserByTaggedUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.DirectTweetRepository.UserByTaggedUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>44cf101bd6fe1d9016e005581242bfb2</Hash>
</Codenesium>*/