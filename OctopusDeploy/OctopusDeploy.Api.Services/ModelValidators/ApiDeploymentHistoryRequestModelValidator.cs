using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiDeploymentHistoryRequestModelValidator : AbstractApiDeploymentHistoryRequestModelValidator, IApiDeploymentHistoryRequestModelValidator
	{
		public ApiDeploymentHistoryRequestModelValidator(IDeploymentHistoryRepository deploymentHistoryRepository)
			: base(deploymentHistoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeploymentHistoryRequestModel model)
		{
			this.ChannelIdRules();
			this.ChannelNameRules();
			this.CompletedTimeRules();
			this.CreatedRules();
			this.DeployedByRules();
			this.DeploymentNameRules();
			this.DurationSecondsRules();
			this.EnvironmentIdRules();
			this.EnvironmentNameRules();
			this.ProjectIdRules();
			this.ProjectNameRules();
			this.ProjectSlugRules();
			this.QueueTimeRules();
			this.ReleaseIdRules();
			this.ReleaseVersionRules();
			this.StartTimeRules();
			this.TaskIdRules();
			this.TaskStateRules();
			this.TenantIdRules();
			this.TenantNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentHistoryRequestModel model)
		{
			this.ChannelIdRules();
			this.ChannelNameRules();
			this.CompletedTimeRules();
			this.CreatedRules();
			this.DeployedByRules();
			this.DeploymentNameRules();
			this.DurationSecondsRules();
			this.EnvironmentIdRules();
			this.EnvironmentNameRules();
			this.ProjectIdRules();
			this.ProjectNameRules();
			this.ProjectSlugRules();
			this.QueueTimeRules();
			this.ReleaseIdRules();
			this.ReleaseVersionRules();
			this.StartTimeRules();
			this.TaskIdRules();
			this.TaskStateRules();
			this.TenantIdRules();
			this.TenantNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ae68a009800edf5c27e1b281c596f4d6</Hash>
</Codenesium>*/