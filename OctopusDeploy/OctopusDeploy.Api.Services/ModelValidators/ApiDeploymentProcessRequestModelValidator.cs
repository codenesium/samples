using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiDeploymentProcessRequestModelValidator : AbstractApiDeploymentProcessRequestModelValidator, IApiDeploymentProcessRequestModelValidator
	{
		public ApiDeploymentProcessRequestModelValidator(IDeploymentProcessRepository deploymentProcessRepository)
			: base(deploymentProcessRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeploymentProcessRequestModel model)
		{
			this.IsFrozenRules();
			this.JSONRules();
			this.OwnerIdRules();
			this.RelatedDocumentIdsRules();
			this.VersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentProcessRequestModel model)
		{
			this.IsFrozenRules();
			this.JSONRules();
			this.OwnerIdRules();
			this.RelatedDocumentIdsRules();
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
    <Hash>190598ba1b5c42d797d7e4d86b3a2398</Hash>
</Codenesium>*/