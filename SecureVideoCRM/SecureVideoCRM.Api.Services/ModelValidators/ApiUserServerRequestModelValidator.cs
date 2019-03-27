using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class ApiUserServerRequestModelValidator : AbstractApiUserServerRequestModelValidator, IApiUserServerRequestModelValidator
	{
		public ApiUserServerRequestModelValidator(IUserRepository userRepository)
			: base(userRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUserServerRequestModel model)
		{
			this.EmailRules();
			this.PasswordRules();
			this.StripeCustomerIdRules();
			this.SubscriptionTypeIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model)
		{
			this.EmailRules();
			this.PasswordRules();
			this.StripeCustomerIdRules();
			this.SubscriptionTypeIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>d6998cf39fcba96d4beac47368de300a</Hash>
</Codenesium>*/