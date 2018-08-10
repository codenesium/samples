using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiReleaseRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiReleaseRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiReleaseRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>c285c1a8b5d58b5ab0e75a14a6f54dc6</Hash>
</Codenesium>*/