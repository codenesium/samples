using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiSubscriptionRequestModelValidator : AbstractApiSubscriptionRequestModelValidator, IApiSubscriptionRequestModelValidator
	{
		public ApiSubscriptionRequestModelValidator(ISubscriptionRepository subscriptionRepository)
			: base(subscriptionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSubscriptionRequestModel model)
		{
			this.IsDisabledRules();
			this.JSONRules();
			this.NameRules();
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiSubscriptionRequestModel model)
		{
			this.IsDisabledRules();
			this.JSONRules();
			this.NameRules();
			this.TypeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>eb44e32bcefc40ab75f7e7bb4b8e7a43</Hash>
</Codenesium>*/