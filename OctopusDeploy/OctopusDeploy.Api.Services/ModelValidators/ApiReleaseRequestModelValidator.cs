using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiReleaseRequestModelValidator : AbstractApiReleaseRequestModelValidator, IApiReleaseRequestModelValidator
	{
		public ApiReleaseRequestModelValidator(IReleaseRepository releaseRepository)
			: base(releaseRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiReleaseRequestModel model)
		{
			this.AssembledRules();
			this.ChannelIdRules();
			this.JSONRules();
			this.ProjectDeploymentProcessSnapshotIdRules();
			this.ProjectIdRules();
			this.ProjectVariableSetSnapshotIdRules();
			this.VersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiReleaseRequestModel model)
		{
			this.AssembledRules();
			this.ChannelIdRules();
			this.JSONRules();
			this.ProjectDeploymentProcessSnapshotIdRules();
			this.ProjectIdRules();
			this.ProjectVariableSetSnapshotIdRules();
			this.VersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4f2d3bd81a07ec0293243e3185808e93</Hash>
</Codenesium>*/