using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public abstract class AbstractApiSubscriptionServerRequestModelValidator : AbstractValidator<ApiSubscriptionServerRequestModel>
	{
		private int existingRecordId;

		protected ISubscriptionRepository SubscriptionRepository { get; private set; }

		public AbstractApiSubscriptionServerRequestModelValidator(ISubscriptionRepository subscriptionRepository)
		{
			this.SubscriptionRepository = subscriptionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSubscriptionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void StripePlanNameRules()
		{
			this.RuleFor(x => x.StripePlanName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.StripePlanName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>da17fcd8665a5553fe93eeb6855358bb</Hash>
</Codenesium>*/