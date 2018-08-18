using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiMutexRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMutexRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiMutexRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>5d91cf3413a1d0391b878667264f0f61</Hash>
</Codenesium>*/