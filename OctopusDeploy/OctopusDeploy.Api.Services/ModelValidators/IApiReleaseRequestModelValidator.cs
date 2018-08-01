using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiReleaseRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiReleaseRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiReleaseRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>d5c3681b0b5a121b900bdc9d0abca617</Hash>
</Codenesium>*/