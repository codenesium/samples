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
	public class ApiSubscriptionServerRequestModelValidator : AbstractValidator<ApiSubscriptionServerRequestModel>, IApiSubscriptionServerRequestModelValidator
	{
		private int existingRecordId;

		protected ISubscriptionRepository SubscriptionRepository { get; private set; }

		public ApiSubscriptionServerRequestModelValidator(ISubscriptionRepository subscriptionRepository)
		{
			this.SubscriptionRepository = subscriptionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSubscriptionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSubscriptionServerRequestModel model)
		{
			this.NameRules();
			this.StripePlanNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSubscriptionServerRequestModel model)
		{
			this.NameRules();
			this.StripePlanNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>2e1bb5196f95b903a80d8388beeaec2e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/