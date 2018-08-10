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
    <Hash>683f11e4a40835df6a83ddfecaf86f39</Hash>
</Codenesium>*/