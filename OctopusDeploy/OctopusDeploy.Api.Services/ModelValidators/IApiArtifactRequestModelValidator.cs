using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiArtifactRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiArtifactRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiArtifactRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>061dd879a929610159dc779d39330d98</Hash>
</Codenesium>*/