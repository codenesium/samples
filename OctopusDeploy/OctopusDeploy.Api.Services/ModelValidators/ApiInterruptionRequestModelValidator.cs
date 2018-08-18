using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiInterruptionRequestModelValidator : AbstractApiInterruptionRequestModelValidator, IApiInterruptionRequestModelValidator
	{
		public ApiInterruptionRequestModelValidator(IInterruptionRepository interruptionRepository)
			: base(interruptionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiInterruptionRequestModel model)
		{
			this.CreatedRules();
			this.EnvironmentIdRules();
			this.JSONRules();
			this.ProjectIdRules();
			this.RelatedDocumentIdsRules();
			this.ResponsibleTeamIdsRules();
			this.StatusRules();
			this.TaskIdRules();
			this.TenantIdRules();
			this.TitleRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiInterruptionRequestModel model)
		{
			this.CreatedRules();
			this.EnvironmentIdRules();
			this.JSONRules();
			this.ProjectIdRules();
			this.RelatedDocumentIdsRules();
			this.ResponsibleTeamIdsRules();
			this.StatusRules();
			this.TaskIdRules();
			this.TenantIdRules();
			this.TitleRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>aac4c31797cc38fe18cf3917d9c6e7f7</Hash>
</Codenesium>*/