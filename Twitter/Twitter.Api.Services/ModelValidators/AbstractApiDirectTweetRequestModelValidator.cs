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
	public abstract class AbstractApiDirectTweetRequestModelValidator : AbstractValidator<ApiDirectTweetRequestModel>
	{
		private int existingRecordId;

		private IDirectTweetRepository directTweetRepository;

		public AbstractApiDirectTweetRequestModelValidator(IDirectTweetRepository directTweetRepository)
		{
			this.directTweetRepository = directTweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDirectTweetRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ContentRules()
		{
			this.RuleFor(x => x.Content).NotNull();
			this.RuleFor(x => x.Content).Length(0, 140);
		}

		public virtual void DateRules()
		{
		}

		public virtual void TaggedUserIdRules()
		{
			this.RuleFor(x => x.TaggedUserId).MustAsync(this.BeValidUserByTaggedUserId).When(x => x?.TaggedUserId != null).WithMessage("Invalid reference");
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
    <Hash>e41b2c69764318496833025bce3df944</Hash>
</Codenesium>*/