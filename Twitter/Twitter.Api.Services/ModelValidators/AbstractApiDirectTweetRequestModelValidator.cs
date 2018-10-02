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
			this.RuleFor(x => x.TaggedUserId).MustAsync(this.BeValidUser).When(x => x?.TaggedUserId != null).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		private async Task<bool> BeValidUser(int id,  CancellationToken cancellationToken)
		{
			var record = await this.directTweetRepository.GetUser(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>ff4a16848af5e57270875331e097d51f</Hash>
</Codenesium>*/