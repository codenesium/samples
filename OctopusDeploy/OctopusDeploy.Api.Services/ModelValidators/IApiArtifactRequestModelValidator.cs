using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiArtifactRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiArtifactRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiArtifactRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>5b00536e19e4ad6259d6da4368bec58d</Hash>
</Codenesium>*/