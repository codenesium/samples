using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiTeamRequestModelValidator : AbstractApiTeamRequestModelValidator, IApiTeamRequestModelValidator
	{
		public ApiTeamRequestModelValidator(ITeamRepository teamRepository)
			: base(teamRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model)
		{
			this.EnvironmentIdsRules();
			this.JSONRules();
			this.MemberUserIdsRules();
			this.NameRules();
			this.ProjectGroupIdsRules();
			this.ProjectIdsRules();
			this.TenantIdsRules();
			this.TenantTagsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiTeamRequestModel model)
		{
			this.EnvironmentIdsRules();
			this.JSONRules();
			this.MemberUserIdsRules();
			this.NameRules();
			this.ProjectGroupIdsRules();
			this.ProjectIdsRules();
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
    <Hash>5f25ad4cf36872422b7969ccc6c33e35</Hash>
</Codenesium>*/