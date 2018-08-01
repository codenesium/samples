using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiAccountRequestModelValidator : AbstractApiAccountRequestModelValidator, IApiAccountRequestModelValidator
	{
		public ApiAccountRequestModelValidator(IAccountRepository accountRepository)
			: base(accountRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAccountRequestModel model)
		{
			this.AccountTypeRules();
			this.EnvironmentIdsRules();
			this.JSONRules();
			this.NameRules();
			this.TenantIdsRules();
			this.TenantTagsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiAccountRequestModel model)
		{
			this.AccountTypeRules();
			this.EnvironmentIdsRules();
			this.JSONRules();
			this.NameRules();
			this.TenantIdsRules();
			this.TenantTagsRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>826f30fdca098a40db3dc5eff4b57f0c</Hash>
</Codenesium>*/