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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSubscriptionServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>dcdf70851a3a328288157ff16f6de66e</Hash>
</Codenesium>*/