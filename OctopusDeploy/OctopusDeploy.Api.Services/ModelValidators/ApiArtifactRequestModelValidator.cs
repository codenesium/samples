using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiArtifactRequestModelValidator : AbstractApiArtifactRequestModelValidator, IApiArtifactRequestModelValidator
	{
		public ApiArtifactRequestModelValidator(IArtifactRepository artifactRepository)
			: base(artifactRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiArtifactRequestModel model)
		{
			this.CreatedRules();
			this.EnvironmentIdRules();
			this.FilenameRules();
			this.JSONRules();
			this.ProjectIdRules();
			this.RelatedDocumentIdsRules();
			this.TenantIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiArtifactRequestModel model)
		{
			this.CreatedRules();
			this.EnvironmentIdRules();
			this.FilenameRules();
			this.JSONRules();
			this.ProjectIdRules();
			this.RelatedDocumentIdsRules();
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
    <Hash>edf60a21a5840c44e6d68811d761097a</Hash>
</Codenesium>*/