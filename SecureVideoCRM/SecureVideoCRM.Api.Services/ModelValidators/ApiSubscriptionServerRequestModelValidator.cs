using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class ApiSubscriptionServerRequestModelValidator : AbstractApiSubscriptionServerRequestModelValidator, IApiSubscriptionServerRequestModelValidator
	{
		public ApiSubscriptionServerRequestModelValidator(ISubscriptionRepository subscriptionRepository)
			: base(subscriptionRepository)
		{
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
	}
}

/*<Codenesium>
    <Hash>9a6672c42d6c3caec4b6effb4beb3792</Hash>
</Codenesium>*/