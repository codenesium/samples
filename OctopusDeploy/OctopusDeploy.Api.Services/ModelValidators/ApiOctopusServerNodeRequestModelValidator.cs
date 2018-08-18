using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiOctopusServerNodeRequestModelValidator : AbstractApiOctopusServerNodeRequestModelValidator, IApiOctopusServerNodeRequestModelValidator
	{
		public ApiOctopusServerNodeRequestModelValidator(IOctopusServerNodeRepository octopusServerNodeRepository)
			: base(octopusServerNodeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOctopusServerNodeRequestModel model)
		{
			this.IsInMaintenanceModeRules();
			this.JSONRules();
			this.LastSeenRules();
			this.MaxConcurrentTasksRules();
			this.NameRules();
			this.RankRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiOctopusServerNodeRequestModel model)
		{
			this.IsInMaintenanceModeRules();
			this.JSONRules();
			this.LastSeenRules();
			this.MaxConcurrentTasksRules();
			this.NameRules();
			this.RankRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>7ddb58591cccd8230dd14500161a904a</Hash>
</Codenesium>*/