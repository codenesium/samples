using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiLifecycleRequestModelValidator : AbstractApiLifecycleRequestModelValidator, IApiLifecycleRequestModelValidator
	{
		public ApiLifecycleRequestModelValidator(ILifecycleRepository lifecycleRepository)
			: base(lifecycleRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLifecycleRequestModel model)
		{
			this.DataVersionRules();
			this.JSONRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiLifecycleRequestModel model)
		{
			this.DataVersionRules();
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
    <Hash>8ed6367a8981fb29a026da140af5096d</Hash>
</Codenesium>*/