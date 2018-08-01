using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiDeploymentRequestModelValidator : AbstractApiDeploymentRequestModelValidator, IApiDeploymentRequestModelValidator
	{
		public ApiDeploymentRequestModelValidator(IDeploymentRepository deploymentRepository)
			: base(deploymentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRequestModel model)
		{
			this.ChannelIdRules();
			this.CreatedRules();
			this.DeployedByRules();
			this.DeployedToMachineIdsRules();
			this.EnvironmentIdRules();
			this.JSONRules();
			this.NameRules();
			this.ProjectGroupIdRules();
			this.ProjectIdRules();
			this.ReleaseIdRules();
			this.TaskIdRules();
			this.TenantIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentRequestModel model)
		{
			this.ChannelIdRules();
			this.CreatedRules();
			this.DeployedByRules();
			this.DeployedToMachineIdsRules();
			this.EnvironmentIdRules();
			this.JSONRules();
			this.NameRules();
			this.ProjectGroupIdRules();
			this.ProjectIdRules();
			this.ReleaseIdRules();
			this.TaskIdRules();
			this.TenantIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>42a50cd76df29989f9322a27071955c4</Hash>
</Codenesium>*/