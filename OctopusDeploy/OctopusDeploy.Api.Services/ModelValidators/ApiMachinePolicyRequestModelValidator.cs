using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiMachinePolicyRequestModelValidator : AbstractApiMachinePolicyRequestModelValidator, IApiMachinePolicyRequestModelValidator
	{
		public ApiMachinePolicyRequestModelValidator(IMachinePolicyRepository machinePolicyRepository)
			: base(machinePolicyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMachinePolicyRequestModel model)
		{
			this.IsDefaultRules();
			this.JSONRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachinePolicyRequestModel model)
		{
			this.IsDefaultRules();
			this.JSONRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8bf6ff6f936d03bf4feef1868bd56447</Hash>
</Codenesium>*/